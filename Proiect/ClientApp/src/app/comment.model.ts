import { User } from "./user.model";
import { Post } from "./post.model";

export interface Comment {
  id: string;
  content: string;
  user?: User;
  post?: Post;
  postId?: string;
  userId?: string;
}
