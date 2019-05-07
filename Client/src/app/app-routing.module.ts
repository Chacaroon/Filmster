import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {IndexComponent} from './pages/index/index.component';
import {SignInComponent} from './pages/sign-in/sign-in.component';
import {RegisterComponent} from './pages/register/register.component';
import {FilmsComponent} from './pages/films/films.component';
import {NotAuthGuard} from './guards/notAuth/not-auth.guard';
import {AddFilmComponent} from './pages/add-film/add-film.component';
import {AuthGuard} from './guards/auth/auth.guard';
import {FilmComponent} from './pages/film/film.component';

const routes: Routes = [
	{path: '', component: IndexComponent, canActivate: [NotAuthGuard]},
	{path: 'signIn', component: SignInComponent, canActivate: [NotAuthGuard]},
	{path: 'register', component: RegisterComponent, canActivate: [NotAuthGuard]},
	{path: 'films', component: FilmsComponent},
	{path: 'films/add', component: AddFilmComponent, canActivate: [AuthGuard]},
	{path: 'films/:id', component: FilmComponent}
];

@NgModule({
	imports: [RouterModule.forRoot(routes, {useHash: true})],
	exports: [RouterModule]
})

export class AppRoutingModule {
}
