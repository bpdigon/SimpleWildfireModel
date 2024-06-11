import { Routes } from '@angular/router';
import { MenuComponent } from './menu/menu.component';
import { GenerateComponent } from './generate/generate.component';
import { SimulateComponent } from './simulate/simulate.component';
import { NgModule } from '@angular/core';
import { DisplayFireComponent } from './display-fire/display-fire.component';

export const routes: Routes = [
    {
        path: "*",
        component: DisplayFireComponent
    },
    {
        path: 'menu',
        component: MenuComponent
    },
    {
        path: 'generateNew',
        component: GenerateComponent
    },
    {
        path: 'simulate',
        component: SimulateComponent
    }
];
