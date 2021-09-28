import { DogService } from './sevices/dog.service';
import { Component, OnInit } from '@angular/core';
import {Dog} from "./models/dog";

@Component({
  selector: 'app-root',
  templateUrl:"./app.component.html",
  styles: []
})
export class AppComponent implements OnInit {
  dogs : Dog[]= [];
  constructor(private service: DogService){
  }
  ngOnInit(): void {
    this.service.list().subscribe(dogs => {
      this.dogs = dogs;
      console.log(dogs);
    })
  }
    
}
