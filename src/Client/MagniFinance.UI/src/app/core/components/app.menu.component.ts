import { OnInit } from '@angular/core';
import { Component } from '@angular/core';
import { LayoutService } from '../services/app.layout.service';

@Component({
    selector: 'app-menu',
    template: `
    <ul class="layout-menu">
        <ng-container *ngFor="let item of model; let i = index;">
            <li app-menuitem *ngIf="!item.separator" [item]="item" [index]="i" [root]="true"></li>
            <li *ngIf="item.separator" class="menu-separator"></li>
        </ng-container>
    </ul>
    `
})
export class AppMenuComponent implements OnInit {

    model: any[] = [];

    constructor(public layoutService: LayoutService) { }

    ngOnInit() {
        this.model = [
            {
                label: 'Magni College',
                items: [
                    { label: 'Dashboard', icon: 'pi pi-fw pi-home', routerLink: ['/'] },
                    { label: 'Teachers', icon: 'pi pi-fw pi-users', routerLink: ['/teachers'] },
                    { label: 'Students', icon: 'pi pi-fw pi-users', routerLink: ['/students'] },
                    { label: 'Courses', icon: 'pi pi-fw pi-bars', routerLink: ['/courses'] }
                ]
            }
        ];
    }
}
