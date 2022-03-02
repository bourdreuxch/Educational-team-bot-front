import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PipeExamplePipe } from './pipes/pipe-example.pipe';
import { NavbarComponent } from './components/navbar/navbar.component';

const declarations = [
    PipeExamplePipe,
    NavbarComponent
]

@NgModule({
  declarations: [
    ...declarations,
  ],
  imports: [
    CommonModule
  ],
  exports: [
    PipeExamplePipe,
    NavbarComponent
  ]
})
export class SharedModule { }
