import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Movie } from 'src/app/models/movie';
import { MovieService } from 'src/app/services/movie.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-add-edit-movie',
  templateUrl: './add-edit-movie.component.html',
  styleUrls: ['./add-edit-movie.component.css']
})
export class AddEditMovieComponent implements OnInit {

  movie = new Movie();
  
  constructor(private movieService: MovieService, private router: Router) {}

  ngOnInit(): void {
    
  }

  addEdit(movie: Movie) {
    debugger;
    try {
        this.movieService.addMovie(movie).subscribe(data => {
        
          if (!data) {
            Swal.fire(
              'Add Movie!',
              'Something went wrong!',
              'error'
            )
          }else {
            Swal.fire(
              'Add Movie!',
              'You have successfully added a new movie.',
              'success'
            ).then(() => {
              this.router.navigate(['/movie']);
            })
          }
        });
      } catch (error) {
        console.log(error);
      }
  }
      
}
