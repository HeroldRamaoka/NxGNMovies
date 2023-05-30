import { Component } from '@angular/core';

@Component({
  selector: 'app-actions-renderer',
  template: `
    <button (click)="onEditClick()">Edit</button>
    <button (click)="onDeleteClick()">Delete</button>
  `,
  styleUrls: ['./actions-renderer.component.css']
})
export class ActionsRendererComponent {

  params: any;

  agInit(params: any) {
    this.params = params;
  }

  onEditClick() {
    this.params.onEdit(this.params);
  }

  onDeleteClick() {
    this.params.onDelete(this.params);
  }
}
