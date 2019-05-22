import { GenreFilter } from './genre-filter';
import { ActorFilter } from './actor-filter';
import { ProducerFilter } from './producer-filter';

export class Filters {
	public genres: GenreFilter[];
	public actors: ActorFilter[];
	public producers: ProducerFilter[];
}
