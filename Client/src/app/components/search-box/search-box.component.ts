import { Component, ElementRef, OnInit } from '@angular/core';
import { SearchFilmsService } from '../../services/searchFilms/search-films.service';

@Component({
  selector: 'app-search-box',
  templateUrl: './search-box.component.html',
  styleUrls: ['./search-box.component.scss']
})
export class SearchBoxComponent implements OnInit {

  constructor(private searchFilmService: SearchFilmsService,
			  private elem: ElementRef) { }

  ngOnInit() {
  }

}
