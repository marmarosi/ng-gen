/* 3rd party libraries */
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

/* globally accessible app code in every feature module */
import { HttpServiceBase } from 'www/shared';
import { environment } from 'www/environments';

/* locally accessible feature module code, always use relative path */
// import { #PascalSingle#Dto, #PascalSingle#ListItemDto, #PascalSingle#ViewDto } from './interfaces';

@Injectable({
  providedIn: 'root'
})
export class #PascalSingle#Api extends HttpServiceBase {

  constructor(private http: HttpClient) {
    super(environment.apiUrl, '/api/#dash-single#');
  }

  // get#PascalSingle#s(): Observable<Array<#PascalSingle#ListItemDto>> {
  //
  //   return this.http.get<Array<#PascalSingle#ListItemDto>>(
  //     `${this.baseUrl}`
  //   );
  // }
  //
  // get#PascalSingle#View(
  //   #camelSingle#Key: number
  // ): Observable<#PascalSingle#ViewDto> {
  //
  //   return this.http.get<#PascalSingle#ViewDto>(
  //     `${this.baseUrl}/${#camelSingle#Key}/view`
  //   );
  // }
  //
  // get#PascalSingle#(
  //   #camelSingle#Key: number
  // ): Observable<#PascalSingle#Dto> {
  //
  //   return this.http.get<#PascalSingle#Dto>(
  //     `${this.baseUrl}/${#camelSingle#Key}`
  //   );
  // }
  //
  // create#PascalSingle#(
  //   #camelSingle#: #PascalSingle#Dto
  // ): Observable<#PascalSingle#Dto> {
  //
  //   return this.http.post<#PascalSingle#Dto>(
  //     `${this.baseUrl}`,
  //     #camelSingle#
  //   );
  // }
  //
  // update#PascalSingle#(
  //   #camelSingle#: #PascalSingle#Dto
  // ): Observable<#PascalSingle#Dto> {
  //
  //   return this.http.put<#PascalSingle#Dto>(
  //     `${this.baseUrl}`,
  //     #camelSingle#
  //   );
  // }
  //
  // remove#PascalSingle#(
  //   #camelSingle#Key: number
  // ): Observable<void> {
  //
  //   return this.http.delete<void>(
  //     `${this.baseUrl}/${#camelSingle#Key}`
  //   );
  // }
}