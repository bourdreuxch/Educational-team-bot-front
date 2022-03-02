import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PipeExamplePipe } from './pipes/pipe-example.pipe';
import { NavbarComponent } from './components/navbar/navbar.component';



@NgModule({
  declarations: [
    PipeExamplePipe,
    NavbarComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    PipeExamplePipe
  ]
})
export class SharedModule { }
