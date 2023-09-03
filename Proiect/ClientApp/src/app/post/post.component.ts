import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from '../auth.service';
import { Post } from '../post.model';
import { PostService } from '../post.service';


@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css']
})
export class PostComponent implements OnInit
{
  @Input()
  post!: Post;
  userRole = '';
  constructor(private route: ActivatedRoute, private router: Router, private http: HttpClient, private authService: AuthService, private postService: PostService) {
    this.userRole = "";
  }
    ngOnInit(): void {
      this.authService.isAdmin().subscribe((isAdmin: boolean) => {
        if (isAdmin) this.userRole = "Admin";
        else this.userRole = "";
      });
    }
  deletePost(postId: string) {
    const token = localStorage.getItem('jwtToken');
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
    const requestOptions = { headers: headers };

    const deleteUrl = `https://localhost:7034/api/post/delete-post/${postId}`;


    this.http.delete(deleteUrl, requestOptions).subscribe(
      () => {
        console.log('Post deleted successfully');
        this.postService.postDeleted.emit(); 
       
      },
      (error) => {
        console.error('Error deleting post:', error);
       
      }
    );
  }
  savePost(postId: string) {
    const token = localStorage.getItem('jwtToken');
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
    const requestOptions = { headers: headers };
    const saveUrl = `https://localhost:7034/api/post/save-post/${postId}`;

   
    this.http.delete(saveUrl, requestOptions).subscribe(
      () => {
        console.log('Post deleted successfully');
        this.postService.postDeleted.emit();
       
      },
      (error) => {
        console.error('Error deleting post:', error);
       
      }
    );
  }
  goToComments(postId: string) {
    this.router.navigate(['/post', postId]);
  }
}
