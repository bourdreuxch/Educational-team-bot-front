import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { MsalGuard, MsalInterceptor } from '@azure/msal-angular';

export const environment = {
  production: false,
  apiEndpoint: '',
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: MsalInterceptor,
      multi: true,
    },
    MsalGuard,
  ],
  clientId: '49921f5f-7322-44f6-a1f9-95428f66560a',
  tenantId: 'fefe9af7-f330-429d-8087-f5e656f7a7ce',
  redirectUri: 'http://localhost:4200',
  postLogoutRedirectUri: 'http://localhost:4200',
};
