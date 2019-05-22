import { GenreFilter } from '../filters/genre-filter';
import { ActorFilter } from '../filters/actor-filter';
import { ProducerFilter } from '../filters/producer-filter';

export class Film {
	public id: string;
	public title: string;
	public year: number;
	public description: string;
	public rating: number;
	public uri: string;
	public duration: string;

	public genres: GenreFilter[];
	public actors: ActorFilter[];
	public producers: ProducerFilter[];
}
