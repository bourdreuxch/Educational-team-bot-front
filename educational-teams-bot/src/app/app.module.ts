import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SharedModule } from './shared/shared.module';
import { CoreModule } from './core/core.module';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { MsalModule } from '@azure/msal-angular';
import { InteractionType, PublicClientApplication } from '@azure/msal-browser';
import { environment } from 'src/environments/environment';
import { FeaturesModule } from './features/features.module';

const imports = [
  BrowserModule,
  AppRoutingModule,
  SharedModule,
  CoreModule,
  NgbModule,
  MsalModule.forRoot(
    new PublicClientApplication({
      auth: {
        clientId: environment.clientId,
        authority: `https://login.microsoftonline.com/${environment.tenantId}`,
        redirectUri: environment.redirectUri,
      },
      cache: {
        cacheLocation: 'localStorage',
      },
    }),
    {
      interactionType: InteractionType.Redirect, // MSAL Guard Configuration
      authRequest: {
        scopes: ['api://bc4ba3e1-6c39-4b50-ba44-6b6b37b7fd4d/access_as_user'],
      },
    },
    {
      interactionType: InteractionType.Redirect, // MSAL Interceptor Configuration
      protectedResourceMap: new Map([
        [
          'http://localhost:5025/api/users',
          ['api://bc4ba3e1-6c39-4b50-ba44-6b6b37b7fd4d/access_as_user'],
        ],
        ['https://graph.microsoft.com/v1.0/me', ['user.read']],
      ]),
    }
  ),
  FeaturesModule,
];

@NgModule({
  declarations: [AppComponent],
  imports: [...imports],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
