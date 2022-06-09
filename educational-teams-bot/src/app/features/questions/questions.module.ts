import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { QuestionsComponent } from './components/questions/questions.component';
import { HttpClientModule } from '@angular/common/http';
import { questionsFeatureKey, reducer } from './state/questions.reducer';
import { StoreModule } from '@ngrx/store';

@NgModule({
  declarations: [QuestionsComponent],
  imports: [
    CommonModule,
    HttpClientModule,
    StoreModule.forFeature(questionsFeatureKey, reducer),
  ],
})
export class QuestionsModule {}
