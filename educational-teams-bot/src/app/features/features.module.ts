import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardModule } from './dashboard/dashboard.module';
import { FeaturesRoutingModule } from './features-routing.module';

@NgModule({
  declarations: [],
  imports: [CommonModule, DashboardModule, FeaturesRoutingModule],
})
export class FeaturesModule {}
