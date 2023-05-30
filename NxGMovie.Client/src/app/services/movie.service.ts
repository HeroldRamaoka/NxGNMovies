import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environment/environment';
import { Movie } from '../models/movie';

@Injectable({
  providedIn: 'root'
})
export class MovieService {

  constructor(private http: HttpClient) { }

  public getMovies() : Observable<any> {
    const moviesUrl = "get/movies";
    return this.http.get<any>(`${environment.baseApiUrl}${moviesUrl}`); 
  }

  public getCoffee(id: any) : any {
    const coffeeUrl = "Coffee?id=";

    return this.http.get<any>(`${environment.baseApiUrl}${coffeeUrl}${id}`); 
  }

  public addMovie(movie: Movie) : Observable<Movie> {
    const newMovieUrl = "add/movie";
    return this.http.post<Movie>(
      `${environment.baseApiUrl}${newMovieUrl}`,
      movie);
  }

  editMovie(movie: Movie) {
    const updateUrl = "edit";
    return this.http.put<Movie>(
      `${environment.baseApiUrl}${updateUrl}`,
      { movie }
    );
  }

  public deleteMovie(movie: Movie) : any {
    const deleteUrl = "delete";
    
    return this.http.delete<Movie>(
      `${environment.baseApiUrl}${deleteUrl}`, movie.id);
  }
}
