import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AngularMaterialModule } from './app.module.material';

import { AppRouter } from './app.routing';
import { AppConfig } from './app.config';

import { AppComponent } from './components/app/app.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { BoardComponent } from "./components/board/board.component";

@NgModule({
    declarations: [
        AppComponent,
        CounterComponent,
        FetchDataComponent,
        BoardComponent,
        HomeComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        AngularMaterialModule,
        AppRouter
    ],
    providers: [
        AppConfig
    ]
})
export class AppModuleShared {
}
