import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PostService } from '../post.service';
import { Comment } from '../comment.model';
import { CommentDto } from '../commentDto.model';
@Component({
  selector: 'app-post-with-comments',
  templateUrl: './post-with-comments.component.html',
  styleUrls: ['./post-with-comments.component.css']
})
export class PostWithCommentsComponent implements OnInit {
  postId: string ;
  post: any;
  comments: Comment[] = [];
  newComment!: string;
  newComm: CommentDto = {
     postId: '',
    content: ''
  }
  constructor(private route: ActivatedRoute, private http: HttpClient, private postService: PostService) { this.postId = ""; }

  ngOnInit(): void {

    this.route.paramMap.subscribe(params => {
      const ok = params.get('id'); 
      if (ok != null) {
        this.postId = ok;
      }
      
    });
    this.postService.getPostById(this.postId).subscribe((post: any) => {
      this.post = post;
    });
    this.loadComments();
   
  }
  loadComments(): void {

    this.http.get<Comment[]>(`https://localhost:7034/api/post/comments/${this.postId}`).subscribe(comments => {
      this.comments = comments.map(comment => ({
        id: comment.id,
        content: comment.content,
        user: comment.user,
        post: comment.post,
        postId: comment.postId,
        userId: comment.userId,
      }));
    }, error => { console.log(error); });
  }
  addComment(): void {
    if (this.newComment?.trim() === '') {
    
      return;
    }
    const token = localStorage.getItem('jwtToken');
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
    const requestOptions = { headers: headers };
    this.newComm = {
      postId: this.postId,
      content: this.newComment,
      }
    this.http.post<CommentDto>('https://localhost:7034/api/post/newcomment', this.newComm, requestOptions)
      .subscribe(() => {
      
        console.log('New comment created:');
        this.newComment = '';
      
        this.loadComments();
      }, error => {
        console.error('Error creating new post:', error);

      });

  }

}
