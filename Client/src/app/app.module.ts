import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbTimepickerModule, NgbTypeaheadModule } from '@ng-bootstrap/ng-bootstrap';
import { IndexComponent } from './pages/index/index.component';
import { HeaderComponent } from './components/header/header.component';
import { SignInComponent } from './pages/sign-in/sign-in.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { RegisterComponent } from './pages/register/register.component';
import { FilmsComponent } from './pages/films/films.component';
import { JwtInterceptor } from './services/token/jwt-interceptor';
import { BasePageComponent } from './components/base-page/base-page.component';
import { FilmPreviewComponent } from './components/film-preview/film-preview.component';
import { ServiceWorkerModule } from '@angular/service-worker';
import { environment } from '../environments/environment';
import { AddFilmComponent } from './pages/add-film/add-film.component';
import { FilmComponent } from './pages/film/film.component';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { SearchBoxComponent } from './components/search-box/search-box.component';
import { SpinnerComponent } from './components/spinner/spinner.component';
import { AddFilmFormComponent } from './components/add-film-form/add-film-form.component';
import { TitleInputComponent } from './components/add-film-form/title-input/title-input.component';
import { YearInputComponent } from './components/add-film-form/year-input/year-input.component';
import { DurationInputComponent } from './components/add-film-form/duration-input/duration-input.component';
import { FilterInputComponent } from './components/add-film-form/filter-input/filter-input.component';

@NgModule({
	declarations: [
		AppComponent,
		IndexComponent,
		HeaderComponent,
		SignInComponent,
		RegisterComponent,
		FilmsComponent,
		BasePageComponent,
		FilmPreviewComponent,
		AddFilmComponent,
		FilmComponent,
		SidebarComponent,
		SearchBoxComponent,
		SpinnerComponent,
		AddFilmFormComponent,
		TitleInputComponent,
		YearInputComponent,
		DurationInputComponent,
		FilterInputComponent
	],
	imports: [
		NgbTimepickerModule,
		BrowserModule,
		AppRoutingModule,
		ReactiveFormsModule,
		HttpClientModule,
		ServiceWorkerModule.register('ngsw-worker.js', {enabled: environment.production}),
		FormsModule,
		NgbTypeaheadModule
	],
	providers: [
		{
			provide: HTTP_INTERCEPTORS,
			useClass: JwtInterceptor,
			multi: true
		}
	],
	bootstrap: [AppComponent]
})
export class AppModule {
}
