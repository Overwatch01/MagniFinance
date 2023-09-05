import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { NgxsModule } from '@ngxs/store';
import { environment } from 'src/environments/environment';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProgressSpinnerComponent } from './core/components/progress-spinner/progress-spinner.component';
import { CoreModule } from './core/core.module';
import { AppState } from './core/store';
import { SharedModule } from './shared/shared.module';

@NgModule({
  declarations: [
    AppComponent,
    ProgressSpinnerComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    SharedModule,
    CoreModule,
    NgxsModule.forRoot(AppState, { 'developmentMode': !environment.production })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
