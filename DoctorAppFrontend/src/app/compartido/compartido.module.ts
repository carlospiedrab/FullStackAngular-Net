import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { LayoutComponent } from './layout/layout.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { MaterialModule } from '../material/material.module';
import { AppRoutingModule } from '../app-routing.module';
import { LayoutRoutingModule } from './layout-routing.module';

@NgModule({
  declarations: [LayoutComponent, DashboardComponent],
  imports: [CommonModule, MaterialModule, LayoutRoutingModule],
  exports: [
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
    // LayoutComponent, DashboardComponent
  ],
})
export class CompartidoModule {}
