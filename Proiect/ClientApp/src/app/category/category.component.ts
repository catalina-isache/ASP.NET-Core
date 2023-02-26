import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Post } from '../post.model';
@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {


  posts: Post[] = [];

  constructor(private route: ActivatedRoute, private http: HttpClient) { }

  ngOnInit(): void {
    const categoryId = this.route.snapshot.paramMap.get('categoryId');
    console.log(categoryId);
    this.http.get<Post[]>(`https://localhost:7034/posts/category/${categoryId}`).subscribe(posts => {
      this.posts = posts.map(post => ({
        id: post.id,
        title: post.title,
        content: post.content,
        imageURL: post.imageURL,
        categoryForPost: post.categoryForPost,
        comments: post.comments,
        user: post.user,
        userId: post.userId,
        dateCreated: post.dateCreated,
        dateModified: post.dateModified
      }));
    }, error => { console.log(error) } );
  }
}
