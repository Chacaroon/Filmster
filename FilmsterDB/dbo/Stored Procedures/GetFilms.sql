
CREATE procedure GetFilms
@searchQuery nvarchar(max) = '',
@genreIds nvarchar(max),
@actorIds nvarchar(max),
@directorIds nvarchar(max)
as
begin

-- declare variables
declare @isGenresFiter bit = ~dbo.IsNullOrEmpty(@genreIds)
declare @isActorsFilter bit = ~dbo.IsNullOrEmpty(@actorIds)
declare @isDirectorsFilter bit = ~dbo.IsNullOrEmpty(@directorIds)

-- declare base query
declare @filterQuery nvarchar(max) = '
select f.Id from Films f
where f.Title like ''%' + @searchQuery + '%'' '

-- add filtering
if (@isDirectorsFilter = 1)
	set @filterQuery = concat(@filterQuery, ' and f.DirectorId in (select value from STRING_SPLIT(''' + @directorIds +''', '',''))')

if (@isGenresFiter = 1)
	set @filterQuery = concat(@filterQuery, '
	intersect 
	select fg.FilmId 
	from FilmGenre fg
	where fg.GenreId in (select value from STRING_SPLIT(''' + @genreIds + ''', '','')) 
	group by fg.FilmId
	having count(fg.GenreId) = (select count(value) from STRING_SPLIT(''' + @genreIds + ''', '',''))
	')

if (@isActorsFilter = 1)
	set @filterQuery = concat(@filterQuery, '
	intersect 
	select fa.FilmId 
	from FilmActor fa
	where fa.ActorId in (select value from STRING_SPLIT(''' + @actorIds + ''', '','')) 
	group by fa.FilmId
	having count(fa.ActorId) = (select count(value) from STRING_SPLIT(''' + @actorIds + ''', '',''))
	')

declare @ids table(FilmId bigint)

-- select filtered film ids
insert @ids
exec sp_executesql @filterQuery

select * from Films f
inner join FilmGenre fg on fg.FilmId = f.Id
inner join Genres g on fg.GenreId = g.Id

inner join FilmActor fa on fa.FilmId = f.Id
inner join Actors a on fa.ActorId = a.Id

inner join Directors d on f.DirectorId = d.Id
where f.Id in (select FilmId from @ids)

end