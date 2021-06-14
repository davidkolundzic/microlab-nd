
import {throwError as observableThrowError,  Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';

import { HttpHeaders, HttpParams } from '@angular/common/http';

import { HttpErrorResponse } from '@angular/common/http';
import { tap, catchError } from 'rxjs/operators';
import { BlockUIService } from './block-ui.service';



@Injectable()
export class HttpService {

    constructor(private http: HttpClient, private blockUIService: BlockUIService) {
    }

    private token = '';
    tokenKey = 'wb_token';

    set Token(value: string) {
        this.token = value;
        if (value == null) {
            localStorage.removeItem(this.tokenKey);
        } else {
            localStorage.setItem(this.tokenKey, value);
        }
    }
    get Token(): string {
        return localStorage.getItem(this.tokenKey);
    }

    clearToken() {
        localStorage.removeItem(this.tokenKey);
    }

    public post<T>(url: string, object?: any): Observable<T> {

        this.blockUIService.startBlock();

        return this.http.post<T>(url, object, {headers: this.BuildHeaders()}).pipe(
          tap(
            obj => this.blockUIService.stopBlock(),
            obj => this.blockUIService.stopBlock()
          )
        );
    }

    public postNoBlock<T>(url: string, object: any): Observable<T> {
      return this.http.post<T>(url, object, {headers: this.BuildHeaders()});
    }

    public get<T>(url: string, options?: any): Observable<any> {

      this.blockUIService.startBlock();
      if (options == null) {
          options = {};
      }

      options.headers = this.BuildHeaders();

      return this.http.get<T>(url, options).pipe(
        tap(
          obj => this.blockUIService.stopBlock(),
          obj => this.blockUIService.stopBlock()
        ));
    }

    public getNoBlock<T>(url: string, options?: any): Observable<any> {
        if (options == null) {
            options = {};
        }
        options.headers = this.BuildHeaders();
        return this.http.get<T>(url, options);
    }


    private BuildHeaders(timeout?: number): HttpHeaders {
      let headers = new HttpHeaders();
      headers = headers.append('Content-Type', 'application/json; charset=utf-8');
      headers = headers.append('Accept', 'q=0.8;application/json;q=0.9');
      const token = this.Token;
      if (token != null && token.length > 0) {
          headers = headers.append('Authorization', 'Bearer ' + token);
      }      

      return headers;
    }

    public delete<T>(url: string, options?: any) {

      if (options == null) {
          options = {};
      }
      options.headers = this.BuildHeaders();
      return this.http.delete<T>(url, options);
    }

    public put<T>(url: string, object: any): Observable<T> {

      this.blockUIService.startBlock();

      return this.http.put<T>(url, object, {headers: this.BuildHeaders()}).pipe(
        tap(
          obj => this.blockUIService.stopBlock(),
          obj => this.blockUIService.stopBlock()
        )
      );
  }

  public putNoBlock<T>(url: string, object: any): Observable<T> {

      return this.http.put<T>(url, object, {headers: this.BuildHeaders()});
  }


}
