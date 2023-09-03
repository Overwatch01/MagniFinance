import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { BrowserModule } from "@angular/platform-browser";
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SidebarModule } from 'primeng/sidebar';
import { BadgeModule } from 'primeng/badge';
import { RadioButtonModule } from 'primeng/radiobutton';
import { InputSwitchModule } from 'primeng/inputswitch';
import { InputTextModule } from 'primeng/inputtext';
import { RippleModule } from 'primeng/ripple';
import { AppMainComponent } from "./components/app.main.component";
import { AppMenuitemComponent } from "./components/app.menuitem.component";
import { AppSidebarComponent } from "./components/app.sidebar.component";
import { AppTopBarComponent } from "./components/app.topbar.component";
import { RouterModule } from "@angular/router";
import { CommonModule } from "@angular/common";
import { AppMenuComponent } from "./components/app.menu.component";
import { AppNotFoundComponent } from "./errors/app.not-found.component";

@NgModule({
    declarations: [
        AppMainComponent,
        AppMenuitemComponent,
        AppSidebarComponent,
        AppTopBarComponent,
        AppMenuComponent,
        AppNotFoundComponent
    ],
    imports: [
        CommonModule,
        BrowserModule,
        FormsModule,
        HttpClientModule,
        BrowserAnimationsModule,
        InputTextModule,
        SidebarModule,
        BadgeModule,
        RadioButtonModule,
        InputSwitchModule,
        RippleModule,
        RouterModule
    ],
    exports: [ AppMainComponent ]
})

export class CoreModule {}