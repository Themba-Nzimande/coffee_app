import { Component, OnInit } from '@angular/core';


export interface RouteInfo {
    path: string;
    title: string;
    icon: string;
    class: string;
}

export const ROUTES: RouteInfo[] = [
    { path: '/notifications', title: 'Coffee Purchase',     icon:'nc-cart-simple',    class: '' },
    { path: '/user',          title: 'My Loyalty Points',      icon:'nc-diamond',  class: '' },
    { path: '/table',         title: 'Loyalty Points',        icon:'nc-trophy',    class: '' },
];

@Component({
    moduleId: module.id,
    selector: 'sidebar-cmp',
    templateUrl: 'sidebar.component.html',
})

export class SidebarComponent implements OnInit {
    public menuItems: any[];
    ngOnInit() {
        this.menuItems = ROUTES.filter(menuItem => menuItem);
    }
}
