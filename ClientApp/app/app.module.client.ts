import { AccountserviceService } from './services/accountservice.service';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { sharedConfig } from './app.module';

@NgModule({
    bootstrap: sharedConfig.bootstrap,
    declarations: sharedConfig.declarations,
    imports: [
        BrowserModule,
        HttpModule,
        FormsModule,
        ...sharedConfig.imports
    ],
    providers: [
        AccountserviceService,
        { provide: 'ORIGIN_URL', useValue: location.origin }
    ]
})
export class AppModule {
}
