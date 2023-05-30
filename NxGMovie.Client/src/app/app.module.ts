import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MovieComponent } from './components/movie/movie.component';
import { AgGridModule } from 'ag-grid-angular';
import { HttpClientModule } from '@angular/common/http';
import { ActionsRendererComponent } from './components/actions-renderer/actions-renderer.component';
import { AddEditMovieComponent } from './components/add-edit-movie/add-edit-movie.component';

@NgModule({
  declarations: [
    AppComponent,
    MovieComponent,
    ActionsRendererComponent,
    AddEditMovieComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    AgGridModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
