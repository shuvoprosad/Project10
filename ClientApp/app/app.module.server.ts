import { AccountserviceService } from './services/accountservice.service';
import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { ServerModule } from '@angular/platform-server';
import { sharedConfig } from './app.module';


@NgModule({
    bootstrap: sharedConfig.bootstrap,
    declarations: sharedConfig.declarations,
    imports: [
        FormsModule,
        ServerModule,
        ...sharedConfig.imports
    ],
    providers: [
        AccountserviceService
    ]
})
export class AppModule {
}
