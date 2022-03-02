import { NgModule } from '@angular/core';
import {environment} from '../../environments/environment'
import { CommonModule } from '@angular/common';



@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ],
  providers: [
    ...environment.providers
  ]
})
export class CoreModule { }
