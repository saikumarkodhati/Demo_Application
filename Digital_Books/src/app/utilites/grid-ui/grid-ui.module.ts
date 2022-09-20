import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { gridroute } from 'src/app/routing/gridrouter';
import { GridUiComponent } from './grid-ui.component';
import { SignupComponent } from './signup/signup.component';




@NgModule({
  declarations: [
    GridUiComponent,
    SignupComponent
  ],
  imports: [CommonModule,FormsModule,ReactiveFormsModule,RouterModule.forChild(gridroute)],
  exports:[GridUiComponent,CommonModule]
})
export class GridUIModule { }







