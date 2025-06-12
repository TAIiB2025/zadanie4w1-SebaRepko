import { Injectable, NgModule } from '@angular/core';
import { Ksiazka } from '../models/ksiazka';
import { Observable, of } from 'rxjs';
import { KsiazkaBody } from '../models/ksiazka-body';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})

export class ListaService {
  private readonly apiUrl = 'http://localhost:5004/api/ksiazki';

  constructor(private httpClient: HttpClient) { }

  get(): Observable<Ksiazka[]> {
    return this.httpClient.get<Ksiazka[]>(this.apiUrl);
  }

  getByID(id: number): Observable<Ksiazka> {
    return this.httpClient.get<Ksiazka>(`${this.apiUrl}/${id}`);
  }

  delete(id: number): Observable<void> {
    return this.httpClient.delete<void>(`${this.apiUrl}/${id}`);
  }

  put(id: number, body: KsiazkaBody): Observable<void> {
    return this.httpClient.put<void>(`${this.apiUrl}/${id}`, body);
  }

  post(body: KsiazkaBody): Observable<void> {
    return this.httpClient.post<void>(this.apiUrl, body);
  }
}