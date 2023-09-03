import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AuthService } from '../auth.service';
import { Post } from '../post.model';
import { FormsModule } from '@angular/forms';
import { PostDto } from '../postDto.model';
import { PostService } from '../post.service';


@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {

  categoryName: string;
  posts: Post[] = [];
  userRole: string;
  showCreateForm = false;
  newPost: PostDto = {
      title: '',
      imageURL: '',
      content: '',
      categoryName:''
  };

  constructor(private route: ActivatedRoute, private http: HttpClient, private authService: AuthService, private postService: PostService) {
    this.categoryName = "";
    this.userRole = "";
  }

  ngOnInit(): void {
    this.authService.isAdmin().subscribe((isAdmin: boolean) => {
      if (isAdmin) this.userRole = "Admin";
      else this.userRole = "";
    });
    this.postService.postDeleted.subscribe(() => {
      this.loadPosts(); 
    });
  
     this.route.paramMap.subscribe(params => {
      const ok = params.get('categoryId'); 
      if (ok != null) {
        this.categoryName = ok;
      }
      this.loadPosts(); 
    });
  }
  createNewPost(): void {
   
    console.log('Create New Post clicked');
    this.showCreateForm = true; 
   
  }
  loadPosts(): void {
    const token = localStorage.getItem('jwtToken');
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
    const requestOptions = { headers: headers };

    this.http.get<Post[]>(`https://localhost:7034/category/${this.categoryName}`, requestOptions).subscribe(posts => {
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

  onSubmit(): void {
  
    const token = localStorage.getItem('jwtToken');
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
    const requestOptions = { headers: headers };
 
    this.http.post<PostDto>('https://localhost:7034/api/post/new-post', this.newPost, requestOptions)
      .subscribe(() => {
       
        console.log('New post created:');
        this.showCreateForm = false;
      
        this.newPost = {
          title: '',
          imageURL: '',
          content: '',
          categoryName:''
        };
      
        this.loadPosts();
      }, error => {
        console.error('Error creating new post:', error);
       
      });
  }

}
