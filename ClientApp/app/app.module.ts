import { AdminFormComponent } from './components/admin-form/admin-form.component';
import { LoginComponent } from './components/login/login.component';
import { RoomRequestsComponent } from './components/room-requests/room-requests.component';
import { RegistrationComponent } from './components/registration/registration.component';
import { RoomFormComponent } from './components/room-form/room-form.component';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ToastyModule } from 'ng2-toasty';


import { AppComponent } from './components/app/app.component'
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';

export const sharedConfig: NgModule = {
    
    bootstrap: [ AppComponent ],
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        RoomFormComponent,
        RegistrationComponent,
        LoginComponent,
        RoomRequestsComponent,
        AdminFormComponent
    ],
    imports: [
        ToastyModule.forRoot(),
        RouterModule.forRoot([
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: '', redirectTo: 'user/login', pathMatch: 'full' },
            { path: 'room/new', component: RoomFormComponent },
            { path: 'user/new', component: RegistrationComponent },
            { path: 'user/login', component: LoginComponent },
            { path: 'room/requests', component: RoomRequestsComponent },
            { path: 'admin/new', component: AdminFormComponent },
            { path: '**', redirectTo: 'user/login' }
        ])
    ],

};
