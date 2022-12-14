import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class JwtInterceptorService implements HttpInterceptor {

  constructor() { }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    // add auth header with jwt if account is logged in and request is to the api url
    const token = localStorage.getItem("currentUser");
    const isApiUrl = request.url.startsWith("api/");
    if (token!=null && isApiUrl) {
        request = request.clone({
            setHeaders: { Authorization: `Bearer ${token}` }
        });
    }

    return next.handle(request);
}
}
