import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../environments/environment';
import { Observable, of, throwError } from 'rxjs';
import { catchError, debounceTime, distinctUntilChanged, switchMap } from 'rxjs/operators';
import { IPerson } from './models/person';


@Injectable({
  providedIn: 'root'
})
export class PeopleService {

  private API_URL = environment.apiUrl;
  private HTTP_OPTIONS = {};
  constructor(private http: HttpClient) { }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      return throwError(error);
    };
  }

  searchPeople = (text: string) => {
    const url = `${this.API_URL}/getall`;
    if (text.length !== 0) {
      const ret = this.http.get<IPerson[]>(`${url}/${text}`, this.HTTP_OPTIONS)
        .pipe(catchError(this.handleError<IPerson[]>(`Get Users failed for ${text}`))
      );
      return ret;
    }
    else {
      return of({}) as Observable<IPerson[]>;
    }
  }
}
