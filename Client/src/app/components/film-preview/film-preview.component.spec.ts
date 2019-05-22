import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FilmPreviewComponent } from './film-preview.component';

describe('FilmPreviewComponent', () => {
	let component: FilmPreviewComponent;
	let fixture: ComponentFixture<FilmPreviewComponent>;

	beforeEach(async(() => {
		TestBed.configureTestingModule({
			declarations: [FilmPreviewComponent]
		})
			.compileComponents();
	}));

	beforeEach(() => {
		fixture = TestBed.createComponent(FilmPreviewComponent);
		component = fixture.componentInstance;
		fixture.detectChanges();
	});

	it('should create', () => {
		expect(component).toBeTruthy();
	});
});
