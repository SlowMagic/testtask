import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders  } from '@angular/common/http';
import { Observable, EMPTY, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';


@Injectable()
export class HttpService { 
    constructor(private http: HttpClient) {

    }

  private getApiResponse<T>(url: string, method: string, data?: Object): Observable<T> {

        const token = localStorage.token;
        const headers = new HttpHeaders({
            'Content-Type': 'application/json',
            'Authorization': `Bearer ${token}`
         });

         const options = {
            headers: headers
         }

         switch (method) {
             case'GET': { 
                    return this.http.get<T>(url, options).pipe(catchError(this.handleError.bind(this)));
              }
             case 'POST': { 
                    return this.http.post<T>(url, data, options).pipe(catchError(this.handleError.bind(this)));
                }
             case 'PUT': {
                    return this.http.put<T>(url, data, options).pipe(catchError(this.handleError.bind(this)));
                }
             case 'DELETE': {
                    return this.http.delete<T>(url, options).pipe(catchError(this.handleError.bind(this)));
                }
         }
    }

    private  handleError(error: any){
        return throwError(error);
    }


    get<T>(url: string): Observable<T> {
        return this.getApiResponse<T>(url, 'GET');
    }

    post<T, R>(url: string, body: T): Observable<R> {
        return this.getApiResponse<R>(url, 'POST', body);
    }

    put<T, R>(url: string, body: T): Observable<R> {
        return this.getApiResponse<R>(url, 'PUT', body);
    }

    delete<T>(url: string): Observable<T> {
        return this.getApiResponse<T>(url, 'DELETE');
    }

}