import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})

export class HomeComponent implements OnInit {
  categoryNames: string[] = [];

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.http.get<string[]>('https://localhost:7034/categories/names').subscribe(names => {
      this.categoryNames = names;
    });
  }
}
