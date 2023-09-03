import { HttpClient } from '@angular/common/http';
import { Injectable, EventEmitter } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PostService {
  constructor(private http: HttpClient) { }
  getPostById(postId: string): Observable<any> {
    const url = `https://localhost:7034/api/post/${postId}`; 
    return this.http.get(url);
  }
  postDeleted: EventEmitter<void> = new EventEmitter<void>();


}
