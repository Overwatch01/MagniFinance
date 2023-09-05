import { Component, ElementRef, ViewChild } from '@angular/core';
import { MenuItem } from 'primeng/api';
import { LayoutService } from "../services/app.layout.service";

@Component({
    selector: 'app-topbar',
    template: `
    <div class="layout-topbar">
        <a class="layout-topbar-logo" routerLink="">
            <img src="assets/layout/images/magnifinance-logo.svg" alt="logo">
        </a>

        <button #menubutton class="p-link layout-menu-button layout-topbar-button" (click)="layoutService.onMenuToggle()">
            <i class="pi pi-bars"></i>
        </button>
    </div>
    `
})
export class AppTopBarComponent {

    items!: MenuItem[];

    @ViewChild('menubutton') menuButton!: ElementRef;

    @ViewChild('topbarmenubutton') topbarMenuButton!: ElementRef;

    @ViewChild('topbarmenu') menu!: ElementRef;

    constructor(public layoutService: LayoutService) { }
}
