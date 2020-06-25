import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormBuilder, NgForm } from '@angular/forms';
import { PeopleService } from '../people.service';
import { IPerson } from '../models/person';
import { Observable, of, Subject } from 'rxjs';
import { catchError, debounceTime, distinctUntilChanged, switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-people-search',
  templateUrl: './people-search.component.html',
  styleUrls: ['./people-search.component.css']
})
export class PeopleSearchComponent implements OnInit {
  isLoadingResults = false;
  selected: string;
  peopleData: IPerson[];
  peopleGroup = new FormGroup({
    searchTerm: new FormControl()
  });
  public searchTerm$ = new Subject<any>();
  constructor(private peopleService: PeopleService) { }

  ngOnInit(): void {
    this.callService(this.searchTerm$);
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);
      return of(result as T);
    };
  }

  callService(term: Observable<string>) {
    if (term !== undefined || term !== null) {
      term.pipe(
        debounceTime(400)
        , distinctUntilChanged()
        , switchMap((result: string) => this.peopleService.searchPeople(result))
      )
        .subscribe((res: IPerson[]) => {
          this.peopleData = [];
          if (res.length > 0) {
            this.peopleData = res;
          }
          this.isLoadingResults = false;
        },
          (err: any) => {
            this.isLoadingResults = false;
            this.peopleData = [];
            catchError(this.handleError<IPerson[]>(`Error!!`));
          });
    }
  }

  showData(item: IPerson) {
    alert(`Id: ${item.PersonId} Name: ${item.FirstName} ${item.LastName} `);
  }

  hoverRow(event: any) {
    this.selected = event.target.innerText;
  }
}
