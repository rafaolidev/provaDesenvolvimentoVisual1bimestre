import { HttpClient } from '@angular/common/http';
import { Dog } from './../models/dog';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DogService {

  baseURL = "http://localhost:5000/api/dog/";
  constructor(private http: HttpClient) { }
  
  list() : Observable<Dog[]>{
    return this.http.get<Dog[]>(`${this.baseURL}list`);
  }
  listId(id: number) : Observable<Dog[]>{
    return this.http.get<Dog[]>(`${this.baseURL}listbyid/{id}`);
  }
  
}
