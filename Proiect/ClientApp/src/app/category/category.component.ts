import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Post } from '../post.model';
// Import your CategoryService

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {

  categoryName: string;
  posts: Post[] = [];

  constructor(private route: ActivatedRoute, private http: HttpClient) { this.categoryName = ""; }

  ngOnInit(): void {
    // Subscribe to route parameter changes
    this.route.paramMap.subscribe(params => {
      const ok = params.get('categoryId'); // Get the categoryName from the route parameter
      if (ok != null)
        this.categoryName = ok;
      this.loadPosts(); // Load posts based on the new categoryName
    });
  }

  loadPosts(): void {
    this.http.get<Post[]>(`https://localhost:7034/category/${this.categoryName}`).subscribe(posts => {
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
    }, error => { console.log(error); });
  }
}
