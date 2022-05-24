import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardModule } from './dashboard/dashboard.module';
import { FeaturesRoutingModule } from './features-routing.module';
import { QuestionsModule } from './questions/questions.module';

@NgModule({
  declarations: [],
  imports: [CommonModule, DashboardModule, FeaturesRoutingModule, QuestionsModule],
})
export class FeaturesModule {}
