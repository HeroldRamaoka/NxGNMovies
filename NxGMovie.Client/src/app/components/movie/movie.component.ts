import { Component, OnInit } from '@angular/core';
import { ColDef, GridApi, GridOptions } from 'ag-grid-community';
import { AgGridAngular } from 'ag-grid-angular';
import { MovieService } from 'src/app/services/movie.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-movie',
  templateUrl: './movie.component.html',
  styleUrls: ['./movie.component.css']
})
export class MovieComponent implements OnInit {
  movies: Array<any> = new Array<any>();

  constructor(private movieService: MovieService, private router: Router) { }

  async ngOnInit() {
    try {
      this.movieService.getMovies().subscribe(data => {
        this.movies = data.result.movies;
      });
    } catch (error) {
      console.log(error);
    }
  }

  columnDefs = [
    { headerName: 'Name', field: 'name'},
    { headerName: 'Rating', field: 'rating'},
    { headerName: 'Category', field: 'category'},
    {
      headerName: 'Actions',
      cellRenderer: 'actionsRenderer',
      cellRendererParams: {
        onEdit: this.editMovie.bind(this),
        onDelete: this.deleteMovie.bind(this),
      }
    },
  ];

  defaultColDef = {
    sortable: true,
    filter: true,
  };

  

  editMovie(row: any) {
    console.log(row);
  }

  deleteMovie(row: any) {
    console.log(row);
  }

  addMovie() {
    this.router.navigate(['/addEditMovie']);
  }
}
