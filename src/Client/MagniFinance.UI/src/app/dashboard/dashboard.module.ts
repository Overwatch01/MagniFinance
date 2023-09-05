import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { IndexComponent } from './components/index.component';
import { DashboardRoutingModule } from './dashboard-routing.module';



@NgModule({
  declarations: [
    IndexComponent
  ],
  imports: [
    SharedModule,
    DashboardRoutingModule
  ]
})
export class DashboardModule { }
