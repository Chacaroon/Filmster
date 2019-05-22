import { Film } from './film';
import { Filters } from '../filters/filters';

export class FilmsResponse {
	films: Film[];
	filters: Filters;
}
