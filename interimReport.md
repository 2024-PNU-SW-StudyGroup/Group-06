---

# FE

Next Js에서 TS,AppRouter,Tailwind를 기반으로 제작

![스크린샷 2024-11-03 오전 8 17 39](https://github.com/user-attachments/assets/119d5ed0-e25b-410c-b2fe-82f5fd39b03f)


<aside>
💡

보딩 페이지

</aside>

Three를 사용해서 프로젝트의 컨셉인 게임기를 제작.

추후 더 개발하여 모델링과, 상호 작용 등 디자인 개선과 기능 추가 예정

![스크린샷 2024-11-03 오전 8 17 51](https://github.com/user-attachments/assets/08951bfa-2c51-496e-9854-150c38fa7684)


<aside>
💡

게임 페이지

</aside>

추후 유니티 연동 예정

![스크린샷 2024-11-03 오전 8 18 11](https://github.com/user-attachments/assets/0f611121-4f5d-491e-9424-0a67d2753fbd)


<aside>
💡

게시판 페이지

</aside>

인피니티 스크롤을 적용, 백엔드 코드 연결 예정

![스크린샷 2024-11-03 오전 8 18 30](https://github.com/user-attachments/assets/cbb3abbb-9978-4aeb-b75c-745fe11ecec3)


<aside>
💡

로그인 페이지

</aside>

백엔드와 연동 이후 기능 완성 예정

---

# BE

![스크린샷 2024-11-03 오전 8 18 45](https://github.com/user-attachments/assets/678c96ff-b974-430b-a82c-b2f9b8312234)


# users

| 테이블 이름 | 컬럼 설명 | 컬럼명 | 데이터 타입 | 컬럼 키  | null 여부  | 기본값 | 자동 여부  | 비고 |
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| users | 유저 ID | user_id | serial | PK | not null |  | Auto Increment |  |
|  | 유저 이메일 | email | varchar(255) |  | not null |  |  |  |
|  | 비밀번호 | password | varchar(255) |  | not null |  |  | 해싱된 값 저장 |
|  | 닉네임 | user_name | varchar |  |  |  |  |  |
|  | 프로필 사진 | user_image | text |  |  |  |  |  |
|  | 성별 | user_gender | enum (’남성’, ‘여성’) |  |  | 남성 |  |  |
|  | 생년월일 | birth_date | date |  |  |  |  |  |
|  | 한줄소개글 | user_bio | text |  |  |  |  |  |
|  | 점수 | user_score | int |  |  | 10000 |  |  |
|  | 가입 날짜 | user_created_at | **timestamp** |  | not null | now() |  |  |
|  | 프로필 마지막 수정 날짜 | user_updated_at | **timestamp** |  |  | now() |  |  |
|  | 최근 로그인 날짜 | user_last_login | **timestamp** |  |  | now() |  |  |

# social login

| 테이블 이름 | 컬럼 설명 | 컬럼명 | 데이터 타입 | 컬럼 키  | null 여부  | 기본값 | 자동 여부  | 비고 |
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| social_login | 소셜 로그인 id | social_login_id | serial | PK |  |  | Auto Increment |  |
|  | 유저 id | user_id | int | FK(users.user_id) | not null |  |  |  |
|  | 소셜 로그인 제공자 | provider | varchar(50) |  | not null |  |  |  |
|  | 소셜 로그인 제공자의 사용자 id | provider_user_id | varchar(255) |  | not null |  |  |  |
|  | 엑세스 토큰 | access_token | text |  |  |  |  |  |
|  | 리프레쉬 토큰 | refresh_token | text |  |  |  |  |  |
|  | 토큰 만료 시간 | token_expiration | timestamp |  |  |  |  |  |

# boards

| 테이블 이름 | 컬럼 설명 | 컬럼명 | 데이터 타입 | 컬럼 키  | null 여부  | 기본값 | 자동 여부  | 비고 |
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| boards | 게시판 id | board_id | serial | PK |  |  | Auto Increment |  |
|  | 게시판 이름 | board_name | varchar(255) |  | not null |  |  |  |
- 일단 임의로 1 - 자유, 2 - 질문, 3 - 꿀팁

# posts

| 테이블 이름 | 컬럼 설명 | 컬럼명 | 데이터 타입 | 컬럼 키  | null 여부  | 기본값 | 자동 여부  | 비고 |
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| posts | 게시글 id | post_id | serial | PK |  |  | Auto Increment |  |
|  | 유저 id | user_id | int | FK(users.user_id) | not null |  |  |  |
|  | 게시판 | board_id | int | FK(boards.board_id) | not null | 자유 게시판 |  |  |
|  | 게시글 제목 | post_title | varchar(255) |  | not null |  |  |  |
|  | 게시글 내용 | post_content | text |  | not null |  |  |  |
|  | 좋아요 수 | post_likes | int |  |  | 0 |  |  |
|  | 최초 작성 날짜 | post_created_at | timestamp |  | not null | now() |  |  |
|  | 마지막 수정 날짜 | post_updated_at | timestamp |  |  | now() |  |  |

# comments

| 테이블 이름 | 컬럼 설명 | 컬럼명 | 데이터 타입 | 컬럼 키  | null 여부  | 기본값 | 자동 여부  | 비고 |
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| comments | 댓글 id | comment_id | serial | PK |  |  | Auto Increment |  |
|  | 유저 id | user_id | int | FK(users.user_id) | not null |  |  |  |
|  | 게시글 id | post_id | int | FK(posts.post_id) | not null |  |  |  |
|  | 댓글 내용 | comment_content | text |  | not null |  |  |  |
|  | 좋아요 수 | comment_likes | int |  |  | 0 |  |  |
|  | 최초 작성 날짜 | comment_created_at | timestamp |  | not null | now() |  |  |
|  | 마지막 수정 날짜 | comment_updated_at | timestamp |  |  | now() |  |  |



- 게시판 최신순 인기순 → BE vs FE (BE)
- 소셜 로그인은 추후에
- 인증 필요 여부 “?” ⇒ 인증필요할까..? 안필요할까..? 일단은 필요 없다고 생각하고 개발하겠음

## UserDTO

```java
private String email;
private String userName;
private String userImage;
private String userGender;
private LocalDate birthDate;
private String userBio;
private Integer userScore;
```

## JwtResponseDTO

```java
private String jwt;
```

---

# 유니티

![스크린샷 2024-11-03 오전 8 19 01](https://github.com/user-attachments/assets/37cd4bb3-ebad-44eb-b209-8f38cb44eb07)


제작 진행중



https://github.com/user-attachments/assets/f2086f68-6093-4f23-a4f8-54366d59766b



---

# 강화 학습

## Soft Actor Critic

## abstract

> Model-free deep reinforcement learning (RL) algorithms have been demonstrated on a range of challenging decision making and control tasks. 
However, these methods typically suffer from two major challenges: 
**very high sample complexity** and **brittle convergence properties**, which necessitate meticulous hyperparameter tuning. 
Both of these challenges severely limit the applicability of such methods to complex, real-world domains. 
In this paper, we propose soft actor-critic, an off policy actor-critic deep RL algorithm based on the maximum entropy reinforcement learning framework. 
In this framework, the actor aims to maximize expected reward while also maximizing en- tropy. That is, to succeed at the task while acting as randomly as possible. 
Prior deep RL methods based on this framework have been formulated as Q-learning methods. By combining off-policy updates with a stable stochastic actor-critic formu- lation, our method achieves state-of-the-art per- formance on a range of continuous control bench- mark tasks, outperforming prior on-policy and off-policy methods. 
Furthermore, we demonstrate that, in contrast to other off-policy algorithms, our approach is very stable, achieving very similar performance across different random seeds.
> 

<aside>
💡

model-free deep RL은 도전적인 결정과정 및 행동 선택에 있어서 좋은 성과를 입증해왔다.
하지만 현대에 와서는 아주 높은 샘플 복잡성과 불안정한 수렴가능성에 의해 세심한 hyper-parameter 튜닝이 필수적이다. 
이러한 요인은 복잡한 현실문제에 대해 RL의 적용을 제한하였다.
본 논문에서, 연구진은 maximum entropy RL framework 기반 off policy 알고리즘인 Soft Actor-Critic을 제시한다. 
Actor는 entropy가 최대가 되게 하면서 기대 리워드를 최대로 만드는게 목표, 즉 에이전트가 가능한 랜덤하게 action을 선택하되 목표는 성취하게 하는게 목표이다.
앞서 제안된 maximum entropy RL frame work 기반의 모델들은 Q-learning으로써 만들어냈다.
여기에 stable stochastic actor-critic formulation과 off policy를 결합시킴으로써 이전 on, off-policy 알고리즘을 연속 행동 선택 환경에서 능가하며 sota를 달성했다.
게다가, 다른 off policy 알고리즘과 달리 환경 시드가 변해도 유사한 성능을 낸다.(robust하다)

</aside>

## introduction

> Model-free deep reinforcement learning (RL) algorithms have been applied in a range of challenging domains, from games (Mnih et al., 2013; Silver et al., 2016) to robotic control (Schulman et al., 2015). 
The combination of RL and high-capacity function approximators such as neural networks holds the promise of automating a wide range of decision making and control tasks, but widespread adoption of these methods in real-world domains has been hampered by two major challenges. 
First, model-free deep RL methods are notoriously expensive in terms of their sample complexity. Even relatively simple tasks can require millions of steps of data collection, and complex behaviors with high dimensional observations might need substantially more. Second, these methods are often brittle with respect to their hyperparameters: learning rates, exploration constants, and other settings must be set carefully for different problem settings to achieve good results. 
Both of these challenges severely limit the applicability of model-free deep RL to real-world tasks.
> 

<aside>
💡

model-free deep RL은 게임부터 로봇제어까지 광범위하게 적용되고 있다.
RL과 NN같은 높은 용량의 함수 근사기의 조합은 광범위한 의사결정문제, task를 조종을 자동화시킬 수 있어졌다. 그러나 현실 도메인에서 이러한 수단의 적용은 두가지 요인에 의해 방해받는다.
 1. 샘플 복잡도의 관점에서 model free deep RL은 비용이 높다. 비교적 단순한 일에 대해서도 수백만의 데이터 수집 단계를 요구한다. 그리고 고차원적인 관측과 복잡한 행동은 잠재적으로 더 많은 샘플을 요구한다.

2. 이러한 model-free deep RL은 하이퍼파라미터(학습률, 탐험 상수 등)에 의존한다. (불안정하다)
다양한 문제에 대해 좋은 결과를 얻으려면 다양한 문제에 대해 하이퍼 파라미터가 세팅되어야한다.
두가지 도전은 실세계 일에 대해 model-free deep RL의 적용을 제한하고 있다.

</aside>

> One cause for the poor sample efficiency of deep RL methods is on-policy learning: some of the most commonly used deep RL algorithms, such as TRPO (Schulman et al., 2015), PPO (Schulman et al., 2017b) or A3C (Mnih et al., 2016), require new samples to be collected for each gradient step. 
This quickly becomes extravagantly expensive, as the number of gradient steps and samples per step needed to learn an effective policy increases with task complexity. 
Off- policy algorithms aim to reuse past experience. 
This is not directly feasible with conventional policy gradient formulations, but is relatively straightforward for Q-learning based methods (Mnih et al., 2015). 
Unfortunately, the combination of off-policy learning and high-dimensional, nonlinear function approximation with neural networks presents a major challenge for stability and convergence (Bhatnagar et al., 2009). 
This challenge is further exacerbated in continuous state and action spaces, where a separate actor network is often used to perform the maximization in Q-learning. 
A commonly used algorithm in such settings, deep determinis- tic policy gradient (DDPG) (Lillicrap et al., 2015), provides for sample-efficient learning but is notoriously challenging to use due to its extreme brittleness and hyperparameter sensitivity (Duan et al., 2016; Henderson et al., 2017).
> 

<aside>
💡

샘플 복잡성의 원인은 on-policy learning이다. 이는 gredient step마다 새로운 샘플을 요구한다.
효율적인 정책을 학습하기에 요구되는 샘플과 gredient step의 수가 증가함에 따라 급격하게 비용이 증가하였다. off-policy learning은 과거 궤적을 재사용하는데 초점을 둔다. 이는 과거 정책 기울기 방정식으론 실현이 불가능하나, Q-learning 기반 method에선 어렵지 않다. 
off-policy learning과 NN을 이용한 고차원적 비선형 함수근사는 학습 안정성과 수렴에 문제가 있다.
이러한 문제는 개별의 actor가 Q-learning에서 최대화를 수행하는 연속 환경과 action space에서 가속화되고 있다. 
DDPG는 off-policy로 샘플 효율성은 좋지만, 모델이 안정적이지 못하고 파라미터에 민감하다.

</aside>

> We explore how to design an efficient and stable model free deep RL algorithm for continuous state and action spaces. To that end, we draw on the maximum entropy
framework, which augments the standard maximum reward reinforcement learning objective with an entropy maximization term (Ziebart et al., 2008; Toussaint, 2009; Rawlik et al., 2012; Fox et al., 2016; Haarnoja et al., 2017). Maximum entropy reinforcement learning alters the RL objective, though the original objective can be recovered using a temperature parameter (Haarnoja et al., 2017). More importantly, the maximum entropy formulation provides a substantial improvement in exploration and robustness: as discussed by Ziebart (2010), maximum entropy policies are robust in the face of model and estimation errors, and as demonstrated by (Haarnoja et al., 2017), they improve exploration by acquiring diverse behaviors. Prior work has proposed model-free deep RL algorithms that perform on-policy learning with entropy maximization (O’Donoghue et al., 2016), as well as off-policy methods based on soft Q-learning and its variants (Schulman et al., 2017a; Nachum et al., 2017a;
Haarnoja et al., 2017). However, the on-policy variants suffer from poor sample complexity for the reasons discussed above, while the off-policy variants require complex approximate inference procedures in continuous action spaces.
> 

<aside>
💡

우리는 연속 state, action space에서 효율적이고 안정적인 model free deep RL algorithm을 탐색했다. 결과적으로 entropy maximization term으로 기존 최대 보상 강화학습의 목표함수를 보강하는 maximum entropy framework를 채택하였다. 해당 framework는 목표 함수를 변경하지만, temperature 파라미터를 건들여서 본래 목표함수로 변경이 가능하다. maximum entropy formulation은 로버스트하고, 탐험에서의 잠재적인 향상을 가져온다.  최초에 entropy maximization은 on-policy와 soft Q-learning과 variant에 기반한 off-policy method가 제안되었다. 그러나 on-policy는 샘플의 부족성 때문에 고통받고 off-policy는 연속 행동 환경에서 복잡한 근사 추론 절차를 가져야한다.

</aside>

> In this paper, we demonstrate that we can devise an off policy maximum entropy actor-critic algorithm, which we call soft actor-critic (SAC), which provides for both sample efficient learning and stability. This algorithm extends readily to very complex, high-dimensional tasks, such as the Humanoid benchmark (Duan et al., 2016) with 21 action dimensions, where off-policy methods such as DDPG typically struggle to obtain good results (Gu et al., 2016). SAC also avoids the complexity and potential instability associated with approximate inference in prior off-policy maximum entropy algorithms based on soft Q-learning (Haarnoja et al., 2017). We present a convergence proof for policy iteration in the maximum entropy framework, and then introduce a new algorithm based on an approximation to this procedure that can be practically implemented with deep neural networks, which we call soft actor-critic. We present empirical results that show that soft actor-critic attains a substantial improvement in both performance and sample efficiency over both off-policy and on-policy prior methods. We also compare to twin delayed deep deterministic (TD3) policy gradient algorithm (Fujimoto et al., 2018), which is a concurrent work that proposes a deterministic algorithm that substantially improves on DDPG.
> 

<aside>
💡

논문에서 sac라고 부르는 off-policy maximum entropy actor-critic algorithm을 소개하고자 한다. 앞선 문제점인 sample efficient와  stability를 다잡았다. sac는 아주 쉽게 복잡하고 고차원적인 일에 확장될 수 있다. (DDPG가 좋은 성능을 내었던 21차원의 Humanoid 같은.) 
sac는 또한 근사 추론 과정과 연관된 잠재적 불안정성과 복잡성을 피할 수 있다.
우리는 maximum entropy framework에서 정책 반복에 대한 수렴 증명을 제시하고, 이 과정에 대한 근사를 기반으로 sac를 제안한다.
본 알고리즘이  on, off-policy의 앞선 방식보다 샘플 효율성과 성능의 상당한 향상을 가져왔음을 실험적 결과로 제시한다.
우리는 또한 TD3 정책 기울기 알고리즘과 비교를 하였다. 해당 알고리즘은 DDPG에서 향상을 이끌어낸 deterministic algorithm이다.

</aside>

## related work

> Our soft actor-critic algorithm incorporates three key in gredients: an actor-critic architecture with separate policy and value function networks, an off-policy formulation that enables reuse of previously collected data for efficiency, and entropy maximization to enable stability and exploration.
We review prior works that draw on some of these ideas in this section. Actor-critic algorithms are typically derived starting from policy iteration, which alternates between pol
icy evaluation—computing the value function for a policy—and policy improvement—using the value function to obtain a better policy (Barto et al., 1983; Sutton & Barto, 1998). In
large-scale reinforcement learning problems, it is typically impractical to run either of these steps to convergence, and instead the value function and policy are optimized jointly. 
In this case, the policy is referred to as the actor, and the value function as the critic. Many actor-critic algorithms build on the standard, on-policy policy gradient formulation to update the actor (Peters & Schaal, 2008), and many of them also consider the entropy of the policy, but instead of maximizing the entropy, they use it as an regularizer (Schulman et al., 2017b; 2015; Mnih et al., 2016; Gruslys et al., 2017). On-policy training tends to improve stability but results in poor sample complexity.
> 

<aside>
💡

sac는 3가지 핵심적인 요소를 가지고 있다.

1. 분리된 actor-critic 네트워크를 가지고 있다.
2. off-policy 기반 수식
3. 안정적인 수렴과 탐색을 할 수 있는 entropy maximization

본 섹션에서는 이러한 아이디어를 뽑아낸 이전 연구들에 대해 리뷰하려한다.
actor-critic은 정책 반복으로부터 이끌어낸 아이디어이다. 정책 평가 → 정책 가치 계산 → 정책 향상의 과정으로 진행되고, 나은 정책을 얻어내기 위해 가치함수를 사용한다.
수렴을 위해 이러한 과정들을 실행하는 것은 비실용적이고, 대신 가치함수와 정책을 동시에 최적화하게 된다.

정책은 actor로 칭해지고, 가치함수는 critic으로 칭한다. 대다수의 actor-critic 알고리즘은 on-policy 기울기 방정식을 사용한다. 그리고 대다수의 알고리즘은 entropy를 최대화하는 것 대신에 정규화의 목적으로 정책의 entropy를 고려한다. 

on-policy는 안정적이나 sample이 부족하다는 단점이 존재한다.

</aside>

> There have been efforts to increase the sample efficiency while retaining robustness by incorporating off-policy samples and by using higher order variance reduction techniques (O’Donoghue et al., 2016; Gu et al., 2016). However, fully off-policy algorithms still attain better efficiency. A particularly popular off-policy actor-critic method, DDPG(Lillicrap et al., 2015), which is a deep variant of the deterministic policy gradient (Silver et al., 2014) algorithm, uses a Q-function estimator to enable off-policy learning, and a deterministic actor that maximizes this Q-function. As such, this method can be viewed both as a deterministic actor-critic algorithm and an approximate Q-learning algorithm. Unfortunately, the interplay between the deterministic actor network and the Q-function typically makes DDPG extremely difficult to stabilize and brittle to hyperparameter settings (Duan et al., 2016; Henderson et al., 2017). As aconsequence, it is difficult to extend DDPG to complex, high-dimensional tasks, and on-policy policy gradient methods still tend to produce the best results in such settings (Guet al., 2016). Our method instead combines off-policy actor critic training with a stochastic actor, and further aims to maximize the entropy of this actor with an entropy maximization objective. We find that this actually results in a considerably more stable and scalable algorithm that, in practice, exceeds both the efficiency and final performance of DDPG. Asimilar method can be derived as a zero-step
special case of stochastic value gradients (SVG(0)) (Heesset al., 2015). However, SVG(0) differs from our method in that it optimizes the standard maximum expected return objective, and it does not make use of a separate value network,which we found to make training more stable.
> 

<aside>
💡

off-policy 샘플을 통합하고, 고계 분산 감소 기술을 사용함으로써 로버스트함을 유지하되, 샘플 효율을 증가시키려는 시도가 있었다. 하지만 완전한 off-policy 알고리즘은 더 나은 효율을 보여준다. DDPG는 Q 함수 평가자로  off-policy 학습이 가능하게 만들었고, 이 큐 함수를 최대화하기 위해 deterministic actor를 두었다. 이러한 알고리즘은 deterministic actor-critic 알고리즘과 근사 Q-learning 알고리즘으로 볼 수 있다.
하지만 deterministic actor와 Q 함수의 상호작용은 안정화와 하이퍼파라미터 세팅을 어렵게 하였다. 결과적으로  DDPG를 복잡하고 고차원적인 일에 확장하긴 힘들고, on-policy 알고리즘이 동일한 환경에서 여전히 좋은 성과를 내고 있다.  연구진의 목적은 off-policy actor-critic을 stochastic actor에 결합시키는 것이 아니라, entropy maximization objective로 actor의 entropy를 최대화 시키는 것이다. 이것이 상당히 안정적이고 DDPG의 효율을 넘고, 성능을 능가하는 확장가능한 알고리즘임을 알게 되었다. 

비슷한 메소드는 zero-step special case of stochasic value gradient(SVG(0))에서 얻을 수 있었다.  
하지만 해당 메소드는 학습을 안정적으로 하는 네트워크 분리를 사용하지 않았고, standard maximum expected return objective를 최적화한다는 점이 달랐다.

</aside>

> Maximum entropy reinforcement learning optimizes policies to maximize both the expected return and the expected entropy of the policy. This framework has been used in many contexts, from inverse reinforcement learning (Ziebart et al., 2008) to optimal control (Todorov, 2008;
Toussaint, 2009; Rawlik et al., 2012). In guided policy search (Levine & Koltun, 2013; Levine et al., 2016), the maximum entropy distribution is used to guide policy learn Soft Actor-Critic
ing towards high-reward regions. More recently, several papers have noted the connection between Q-learning and policy gradient methods in the framework of maximum entropy learning (O’Donoghue et al., 2016; Haarnoja et al.,2017; Nachum et al., 2017a; Schulman et al., 2017a). While most of the prior model-free works assume a discrete action space, Nachum et al. (2017b) approximate the maximum entropy distribution with a Gaussian and Haarnoja et al. (2017)with a sampling network trained to draw samples from the optimal policy. Although the soft Q-learning algorithm proposed by Haarnoja et al. (2017) has a value function and actor network, it is not a true actor-critic algorithm: the Q-function is estimating the optimal Q-function, and the actor does not directly affect the Q-function except through the data distribution. Hence, Haarnoja et al. (2017) motivates the actor network as an approximate sampler, rather than the actor in an actor-critic algorithm. Crucially, the convergence of this method hinges on how well this sampler approximates the true posterior. In contrast, we prove that our method converges to the optimal policy from a given policy class, regardless of the policy parameterization. Furthermore, these prior maximum entropy methods generally
do not exceed the performance of state-of-the-art off-policy algorithms, such as DDPG, when learning from scratch, though they may have other benefits, such as improved exploration and ease of fine-tuning. In our experiments, we demonstrate that our soft actor-critic algorithm does in fact exceed the performance of prior state-of-the-art off-policy deep RL methods by a wide margin
> 

<aside>
💡

maximum entropy reinforcement learning은 정책을 기대 보상과 정책의 기대 엔트로피가 최대화되게 업데이트한다. 이러한 framework는 다양한 곳에서 사용되고 있다. maximum entropy 분포는 높은 보상의 지역으로 학습하는데 있어 정책 가이드가 될 수 있다. 최근 몇몇 논문은 maximum entropy framework에서 Q-learning과 정책 근사 수단에 주목하고 있다. 앞선 대다수의  model free work들은 이산 행동 차원을 추정하였으나, Nachum 등은 최적정책에서 샘플을 뽑아내 학습한 sampling network와 함께 가우시안을 이용해 maximum entropy 분포를 근사시켰다. soft Q-learning은 value function과 actor function을 가지고 있었다. 하지만 해당 알고리즘은 진정한 actor-critic은 아니었다. Q-function은 최적 Q-function을 추정하였다. 그리고 actor는 데이터 분포를 통하는 것 이외에 직접적으로 Q-function에 영향을 주지 않았다. 이런 이유로 해당 논문에서 actor network는 approximate sampler로 사용되었다.

이 메소드의 수렴은 얼마나 잘 이 샘플러가 근사하는지에 달려있다.
대조적으로 우리는 우리 메소드가 정책 파라미터와 상관없이 주어진 정책 수준에서 최적으로 수렴하는 것을 입증한다. 이러한 이전의 maximum entropy method는 각각의 장점은 있었지만 sota off-policy 알고리즘의 성능을 능가하지 못하였다. 실험을 통해 우리는 sac가 실제로 앞선 sota off-policy 메소드를 큰 폭으로 능가함을 증명한다

</aside>

## Preliminaries

> We first introduce notation and summarize the standard and maximum entropy reinforcement learning frameworks.
> 

<aside>
💡

표기법을 소개하고 standard, maximum entropy 강화학습 프레임워크를 요약한다.

</aside>

### Notation

> We address policy learning in continuous action spaces. We consider an infinite-horizon Markov decision process (MDP), defined by the tuple (S, A, p, r), where the state space S and the action space A are continuous, and the unknown state transition probability p : S * S * A → [0, $\infty$) represents the probability density of the next state $s_{t+1} \in S$ given the current state st S and action at A. The environment emits a bounded reward r : S * A
[$r_{min}$, $r_{max}$] on each transition. We will use $\rho_\pi$($s_t$) and $\rho_\pi$($s_t$, $a_t$) to denote the state and state-action marginals of the trajectory distribution induced by a policy $\pi$($a_t|s_t$).
> 

<aside>
💡

</aside>

## DDPG

https://arxiv.org/abs/1509.02971

# Introduction

해당 논문은 DQN 논문을 많이 이용하였다. DQN은 이산 환경에서 저차원의 행동 공간 관측에 대해 문제를 해결할 수 있었지만, RL이 발전함에 따라서 우리는 고차원적이고 연속적인 행동공간에서 문제를 해결한다. 

### 이산 환경에 대한 알고리즘을 연속 환경에서 적용하는 방법

논문에서는 가장 단순하게 연속 환경을 쪼개어서 이산환경으로 보고 처리하자 라는 아이디어를 제시한다. 하지만, 연속적인 공간을 여러개로 나누면 나누어진 공간수를 N이라고 하였을 때 $action^N$개의 선택지가 생긴다. 이는 지수적으로 증가하기에 더 많은 공간으로 분할함에 따라서 기하급수적으로 커지는 action수를 대면하게 된다. 따라서 모든 경우에 대해 학습하는 과정에서 차원의 저주를 피할 수 없게 된다. 이러한 이유로 이산 환경에 대한 알고리즘은 연속 환경에 적용시키기엔 한계가 존재한다.

따라서 논문에서는 **고차원적이고 연속적인 행동공간에 적용이 가능한 off-policy, actor-critic, model-free하며 심층 함수를 사용해 근사시킨 알고리즘**을 제안한다.

해당 알고리즘은 DPG(deterministic policy gredient) 기반이다. 

단순히 actor-critic method를 인공 신경망 함수에 근사시키는 것은 불안정하다.
이를 완화시키는 방안이 DQN에서 제시되었다. 

1. Replay Buffer를 사용하여 MDP에서 스텝간의 연관성으로 비롯되는 공분산 문제(correlation)를 최소화할 수 있었고, 이를 통해 조금은 안정적인 학습이 가능하게 하였다.
2. $y - \hat{y}$ 형태로 로스를 계산하게 되는데, 두 변수는 같은 파라미터에 대해 파라미터화 되어있다. 그리고 매 타임스텝마다 파라미터가 업데이트되게 되는데, 타겟이 계속해서 변경됨에 따라서 학습이 불안정하게 진행된다. 이를 개선하고자 back up model을 두었다. 해당 모델로 타겟을 예측함으로써 어느정도 고정된 타겟값으로 모델이 학습하게 되었고, 이를 통해 학습이 보다 안정적이게 진행되었다.
3. 부가적으로 Batch Normalization(BN)을 이용하여 모든 입력 샘플의 스케일을 조정하였고, 이롤 통해 모델에 robust한 특성을 추가해주었다.

동일 파라미터값과 동일 네트워크 구조를 이용해 다양한 저차원 관측값을 이용해 정책을 학습시킬 때 DDPG(Deep DPG)는 경쟁력이 있었다. 

→ 다양한 환경에 대해 동일 모델과 파라미터가 좋은 성과를 내는 모습에서 BN을 추가해 robust한 특성을 넣은게 유의미하였음을 알 수 있다.

단순 actor-critic 구조에 나머지는 수식으로 구현되었기에 확장이 용이하다는 장점이 있다.

# background

기본적인 강화학습은 매 타임스텝마다 환경과 소통하는 에이전트가 가정된다.

매 타임스텝 t마다 에이전트는 상태값 $x_t$를 받고, 그에 따라 액션 $a_t$을 취하며, 액선에 따른 보상 $r_t$를 받는다.

환경은 부분적으로 관측될 수 있기 때문에 현 상태를 표현하기 위해 현 상태까지 오게 된 궤적을 필요로 한다. 환경은 관측값과 상태가 동일한 fully-observed한 환경이기에, $s_t=x_t$이다. 

이에 따라서 궤적은 $s_t=(x_1,a_1 ,...,a_{t-1},x_t)=(s_1,a_1 ,...,a_{t-1},s_t)$로 표현된다.

### fully-observed

agent의 action은 env의 observation에 의해 결정된다. agent가 모든 state를 observation할 수 있을 때를 fully-observed라고 표현한다.

반대되는 표현으로는 partially-observed가 있다.

에이전트의 행동은 정책 $\pi$에 의해 결정된다. 

감가율 $\gamma =[0,1]$일 때 $R_t = \sum^T_{i=t}\gamma^{(i-t)}r(s_i,a_i)$이다.

$\rho^\pi$는 정책 $\pi$에 대한 discounted state visitation distribution이다. 

$Q^\pi(s_t,a_t) = E_{r_t,s_{t+1}}[r(s_t,a_t)+\gamma E_{a_{t+1}}[ Q^\pi(s_{t+1},a_{t+1})]]$ 

벨만 방정식에 따른 Q 함수의 재귀적 구조

$Q^\mu(s_t,a_t) = E_{r_t,s_{t+1}}[r(s_t,a_t)+\gamma Q^\mu(s_{t+1},\mu (s_{t+1}))]$

앞선 벨만방정식에서 stochastic하게 action을 뽑아내던 것을 deterministic하게 action을 고름으로써 action에 대한 expectation term이 사라졌다. 

이를 actor-critic에 알고리즘에 적용하게 되면 

![Untitled](https://prod-files-secure.s3.us-west-2.amazonaws.com/08820807-0fa7-42c4-bc95-7d349a6c2119/a3def658-8728-4c48-8e1d-ffad86f95ffa/Untitled.png)

이 된다.

# Algorithm

Q learning은 모든 action space에 대해 탐색하며 결과적으로는 가장 좋은 길을 greedy하게 고른다. 이는 시간만 충분하다면 성능이 보장되는 방법인데, 앞선 introduction에서 말하였듯 행동공간의 선택폭이 기하급수적으로 늘어남에 따라서 다음과 같은 방식은 제한적이다.

state와 action를 매핑시킨 $\mu$라는 함수를 만들어냄


![스크린샷 2024-11-03 오전 8 20 06](https://github.com/user-attachments/assets/3ae1d3bd-999c-4260-a75d-b31d4ce23e97)


다음과 같은 수식으로 업데이트

NFQCA는 batch learning을 통해 안정성을 올리고 있는데, stochastic GD와 batch GD의 차이와 유사했다.

인공지능을 이용한 강화학습은 I.I.D를 추정하려고 한다. 하지만 강화학습은 MDP 특성상 공선성문제가 발생할 수 밖에 없는 구조이다. 

DQN에서 유한한 크기의 캐시 메모리 R에 $(s_t,a_t,r_t,s_{t+1})$을 저장하고, 용량이 다 차면 오래된 정보부터 삭제하게 하였다. replay buffer의 사이즈가 커질수록 공선성은 더욱 더 줄어들게 된다. 또한 업데이트시 미니배치는 균일한 확률분포에서 샘플링된다.  NFQCA의 batch learning의 장점도 가지고 온 모습이다.

백업 모델에 업데이트를 해줄 때 일정 비율($\tau$)만큼 파라미터를 넘겨줌으로써 급격한 변화로 모델의 수렴이 흔들리는 것을 완화하였다.

다양한 환경에서 robust하게 작용하게 하려고, BN을 입력전, 각 모델의 레이어마다 실시해주었다. 

DPG는 분포에서 action을 sampling하던 Stochastic과는 달리 action을 바로 골라낸다. 따라서 탐험을 하게 하는 방법으로 noise를 넣어주게 되었다. 논문에서는 OU noise를 사용하였다.

![스크린샷 2024-11-03 오전 8 19 45](https://github.com/user-attachments/assets/6e83f413-d9db-4a3a-aa9e-d52e8baf61d1)

# Abstract

> We adapt the ideas underlying the success of Deep Q-Learning to the continuous
action domain. We present an actor-critic, model-free algorithm based on the deterministic policy gradient that can operate over continuous action spaces. Using
the same learning algorithm, network architecture and hyper-parameters, our algorithm robustly solves more than 20 simulated physics tasks, including classic
problems such as cartpole swing-up, dexterous manipulation, legged locomotion
and car driving. Our algorithm is able to find policies whose performance is competitive with those found by a planning algorithm with full access to the dynamics
of the domain and its derivatives. We further demonstrate that for many of the
tasks the algorithm can learn policies “end-to-end”: directly from raw pixel inputs
> 

<aside>
💡

우리는 Deep Q-Learning의 성공을 뒷받침하는 아이디어들을 연속적인 행동 영역에 적용했다. 우리는 연속적인 action space에 적용할 수 있는 deterministic policy gradient를 기반으로 한 actor-critic, model-free 알고리즘을 제안한다. 동일한 학습 알고리즘, 네트워크 구조와 하이퍼파라매터들을 사용하여 , 우리의 알고리즘은 Cartpole swing-up, dexterous manipulation, legged locomotion 그리고 car driving과 같은 클래식한 문제을 포함하여 20개 이상의 시뮬레이션 물리적 문제를 안정적으로 해결합니다. 우리의 알고리즘은 도메인의 동역학과 그 미분값에 완전히 접근할 수 있는 계획 알고리즘이 찾은 것과 경쟁력 있는 성능을 보이는 정책들을 찾을 수 있다. 또한 많은 작업에서 알고리즘이 end-to-end : 가공되지 않은 픽셀 입력을 바로 사용하는  방식으로 정책을 학습할 수 있음을 보여준다.

</aside>

# Introduction

> One of the primary goals of the field of artificial intelligence is to solve complex tasks from unprocessed, high-dimensional, sensory input. Recently, significant progress has been made by combining advances in deep learning for sensory processing (Krizhevsky et al., 2012) with reinforcement learning, resulting in the “Deep Q Network” (DQN) algorithm (Mnih et al., 2015) that is capable of human level performance on many Atari video games using unprocessed pixels for input. To do so, deep neural network function approximators were used to estimate the action-value function.
> 

<aside>
💡

인공지능 분야의 주요 목표 중 하나는 가공되지 않은 high-dimensional sensory 입력으로 부터 복잡한 문제를 해결하는 것이다. 최근 sensory 처리를 위한 deep learning의 발전과 강화학습을 결합하여 중요한 진전이 이루어졌고, 그 결과로 가공되지 않은 픽셀 입력을 사용하여 많은 아타리 비디오 게임에서 인간 수준의 성들을 달성하는 “Deep Q Network”(DQN) 알고리즘이 개발되었다. 이를 위해 action-value 함수를 추정하는데 심층 신경망 함수 근사가 사용되었다.

</aside>

> However, while DQN solves problems with high-dimensional observation spaces, it can only handle discrete and low-dimensional action spaces. Many tasks of interest, most notably physical control tasks, have continuous (real valued) and high dimensional action spaces. DQN cannot be straightforwardly applied to continuous domains since it relies on a finding the action that maximizes the action-value function, which in the continuous valued case requires an iterative optimization process at every step.
> 

<aside>
💡

그러나 DQN이 고차원 입력으로 문제를 해결하는 동안, 오직 불연속 적이고 저차원의 액션 공간만을 다룬다. 많은 주요 작업, 특히 물리학을 다루는 작업은 연속적이고 고차원의 액션 공간을 가진다. 연속적인 값은 모든 단계에서 최적화 과정이 필요하지만, DQN은 action-value 함수를 최대화 시키키는 액션을 찾는것에 의존하기에 연속적인 분야에 간단하게 적용할 수 없다.

</aside>

> An obvious approach to adapting deep reinforcement learning methods such as DQN to continuous domains is to to simply discretize the action space. However, this has many limitations, most notably the curse of dimensionality: the number of actions increases exponentially with the number of degrees of freedom. For example, a 7 degree of freedom system (as in the human arm) with the coarsest discretization $a_i \in \{-k, 0, k\}$ for each joint leads to an action space with dimensionality: $3^7 = 2187$. The situation is even worse for tasks that require fine control of actions as they require a correspondingly finer grained discretization, leading to an explosion of the number of discrete actions. Such large action spaces are difficult to explore efficiently, and thus successfully training DQN-like networks in this context is likely intractable. Additionally, naive discretization of action spaces needlessly throws away information about the structure of the action domain, which may be essential for solving many problems.
> 

<aside>
💡

DQN과 같은 심층 강화학습 방법을 연속적인 영역에 적용하는 가장 확실한 방법은 액션 공간을 이산화 시키는 것이다. 그러나, 이 방식은 차원의 저주 : 자유도가 높아질 수록 액션의 개수가 기하급수적으로 늘어나는 것 라고 불리는 많은 한계점을 가진다. 예를 들어 단순한 이산화를 적용한 7개의 자유도를 가지는 시스템 ( 인간팔과 같은 )은 각 연결부 마다 한 차원의 액션 공간을 가진다 : 2187개. 더 세밀하게 조종되어야 하는 상황에선 더 세밀하게 이산화 되어야 하기에 액션의 개수가 폭발적으로 증가하여 더 심각해진다. 이렇게 거대한 액션 공간은 효율적인 탐색을 하는데 어려움이 있으며, 같은 맥락에서 DQN과 같은 네트워크의 성공적인 학습이 어렵다. 여기에 더하여, 액션 공간의 단순한 이산화는 액션을 구성하는데에 있어 많은 문제 해결의 핵심이 될 수 있는 정보를 불필요하게 버리게 된다.

</aside>

> In this work we present a model-free, off-policy actor-critic algorithm using deep function approximators that can learn policies in high-dimensional, continuous action spaces. Our work is based on the deterministic policy gradient (DPG) algorithm (Silver et al., 2014) (itself similar to NFQCA (Hafner & Riedmiller, 2011), and similar ideas can be found in (Prokhorov et al., 1997)). However, as we show below, a naive application of this actor-critic method with neural function approximators is unstable for challenging problems.
> 

<aside>
💡

해당 논문에서 우리는 고차원의 연속 액션 공간에서 정책을 학습할 수 있는 심층 함수 근사를 사용한 model-free, off-policy actor-critic 알고리즘을 제안한다. 이는 deterministic policy gradient (DPG) 알고리즘을 기반으로 하였고 (Proknhorov et al., 1997)에서 비슷한 아이디어를 찾을 수 있다. 그러나, 아래에서 보여지듯, 신경 함수 근사를 적용한 actor-critic 방식을 단순하게 적용하면 까다로운 문제에서는 불안정하다.

</aside>

> Here we combine the actor-critic approach with insights from the recent success of Deep Q Network (DQN) (Mnih et al., 2013; 2015). Prior to DQN, it was generally believed that learning value functions using large, non-linear function approximators was difficult and unstable. DQN is able to learn value functions using such function approximators in a stable and robust way due to two innovations: 1. the network is trained off-policy with samples from a replay buffer to minimize correlations between samples; 2. the network is trained with a target Q network to give consistent targets during temporal difference backups. In this work we make use of the same ideas, along with batch normalization (Ioffe & Szegedy, 2015), a recent advance in deep learning.
> 

<aside>
💡

여기서, 우리는 최근에 성공적인 결과를 보여준 

</aside>

> In order to evaluate our method we constructed a variety of challenging physical control problems that involve complex multi-joint movements, unstable and rich contact dynamics, and gait behavior. Among these are classic problems such as the cartpole swing-up problem, as well as many new domains. A long-standing challenge of robotic control is to learn an action policy directly from raw sensory input such as video. Accordingly, we place a fixed viewpoint camera in the simulator and attempted all tasks using both low-dimensional observations (e.g. joint angles) and directly from
pixels.
> 

<aside>
💡

</aside>

> Our model-free approach which we call Deep DPG (DDPG) can learn competitive policies for all of our tasks using low-dimensional observations (e.g. cartesian coordinates or joint angles) using the same hyper-parameters and network structure. In many cases, we are also able to learn good policies directly from pixels, again keeping hyperparameters and network structure constant.
> 

<aside>
💡

</aside>

> A key feature of the approach is its simplicity: it requires only a straightforward actor-critic architecture and learning algorithm with very few “moving parts”, making it easy to implement and scale to more difficult problems and larger networks. For the physical control problems we compare our results to a baseline computed by a planner (Tassa et al., 2012) that has full access to the underlying simulated dynamics and its derivatives (see supplementary information). Interestingly, DDPG can sometimes find policies that exceed the performance of the planner, in some cases even when learning from pixels (the planner always plans over the underlying low-dimensional state space).
> 

<aside>
💡

</aside>

## TRPO

https://arxiv.org/pdf/1502.05477

# Introduction

정책 최적화를 위한 알고리즘은 3가지 카테고리로 분류된다.

1. policy iteration method
2. policy gradient method
3. derivative-free optimization

연속적 기울기 기반 최적화는 지도학습에서 다수의 파라미터를 갖는 지도학습 문제에 대해 성공적으로 함수를 근사시켰다. 이를 강화학습에도 적용하여 고차원적인 정책학습이 가능하게 하려한다. 

# Preliminaris

S : state

A : action

P : S에서 A를 취해 다음상태 S’로 갈 확률

r : reward

$\rho_0$ : 초기에 어느 상태에서 시작할지에 대한 확률분포

$\gamma$ : 감가율
![스크린샷 2024-11-03 오전 8 20 36](https://github.com/user-attachments/assets/972b513e-5963-4205-8321-8161cc0260ce)


$\eta(\pi)$는 시작시점부터 종단시점까지의 리워드에 감가율을 곱해 더해준 것으로 해당 정책의 성능지표이다.
![스크린샷 2024-11-03 오전 8 20 45](https://github.com/user-attachments/assets/8e5b0623-03ec-4f9a-b540-2c0f6490cb58)


$Q_\pi(s_t,a_t)$, $V_\pi(s_t)$는 해당 시점(t) 이후 취할 수 있는 보상의 가중합이다.
$A_\pi(s,a)$는 미래 액션의 가치에서 현 상태의 보상 추정값을 빼어 줌으로써 해당 액션의 가치를 추정할 수 있다.
![스크린샷 2024-11-03 오전 8 20 55](https://github.com/user-attachments/assets/a6dbf69c-cb06-49ea-b7e7-8bf1d347f029)


$\eta(\tilde\pi)$ 는 업데이트 된 정책  $\tilde\pi$를 이전 정책 $\pi$를 이용해 가치를 얻어낸다. 샘플링은 업데이트 된 정책에서 하고,

가치는 이전 정책에 대해서 매기게 되면 이것이 곧 $\eta(\tilde\pi)$ 가 되었다.
![스크린샷 2024-11-03 오전 8 21 04](https://github.com/user-attachments/assets/92cc3e00-b931-49cd-97a0-c25233887587)


$\rho_0$는 시작지점을 어디로 잡을지에 대한 확률분포였다. 
$\rho_\pi(s)$는 정책$\pi$를 따를 때 s라는 state에 몇번째 차례에 방문할지를 나타내는 확률분포이다.
![스크린샷 2024-11-03 오전 8 21 15](https://github.com/user-attachments/assets/c8cd91ef-cba9-42f7-9ec2-ead7fe148a44)


앞서 나온 $\eta(\tilde\pi)$ 수식에서 기대값(E)를 푼 수식이다. state에서 a를 골랐을 때 A의 기대값이기에 이를 풀어주면 각 state에 도달할 확률과 해당 state에서 정책에 따라 action을 고를 확률이 또 곱해져야한다. 이를 수식으로 보이면 위 식과 같이 된다.

강화학습의 목표는 성능이 향상되는 수식에 따라 정책을 업데이트함으로써 최적의 정책($\pi^*)$을 뽑아내는 것이다. 하지만 마지막 수식을 보게되면 $\rho_{\tilde\pi}(s)$ > 0 이고, $\tilde\pi(a|s)$도 확률이기에 0보다 크다.

결론적으로 $A_\pi(s,a)$가 ≥ 0 이면 어느 한 쌍의 action-state쌍만 향상되더라도 해당 정책은 성능 향상이 보장된다.(쇠퇴하지 않는다.)
![스크린샷 2024-11-03 오전 8 21 24](https://github.com/user-attachments/assets/0bc4b786-378f-45f5-99f3-458a6a07399b)


$$
1)\sum_s\rho_{\tilde\pi(s)}\sum\tilde\pi(a|s)A_\pi(s,a)
$$

$$
2)\sum_s\rho_\pi(s)\sum\tilde\pi(a|s)A_\pi(s,a)
$$

1) 수식과 2)수식의 차이는 state에 방문할 확률분포가 현재 정책을 따르는지, 미래 정책(업데이트 된 정책)을 따르는지이다.

논문에서는 근사과정에서 평가오차와 근사오차로 인해 $A_\pi(s,a)$ 텀이 음수가 될 수 있다고 말을 한다.
gym 환경의 frozen lake 게임을 생각해보자. 에이전트에게 시킨 action과 다른 action이 일정 확률로 발생한다. 이렇듯 에이전트가 state와 action이 정해졌을 때 s’에 갈 확률 P가 정의되는 것은 이러한 오류때문에 그렇다. 각 정책에 이런 오류도 다 포함되어 있을텐데 $\rho_{\tilde\pi}$는 $P_{\tilde\pi}(s)$의 확률을 따른다. 하지만 $A_\pi(s,a)$는 $P_\pi(s)$를 따르고 있기에 우리가 명령한 것과 다른 움직임을 보이면 음의 값이 뜰 수 있다.

그렇기에 정책을 $\pi$로 바꿔준, 2번째 수식이 등장하였다.

이런 차이때문에 두 공식을  $\eta(\tilde\pi)$, $L_\pi(\tilde\pi)$라고 표기한다.
![스크린샷 2024-11-03 오전 8 21 38](https://github.com/user-attachments/assets/7dd93eca-1666-4f76-ae19-68b48bbe609d)


# Monotonic Improvement Guarantee for General Stochastic Policies
![스크린샷 2024-11-03 오전 8 21 58](https://github.com/user-attachments/assets/d12c6234-cc70-4d30-8fed-1b761686520f)



![Untitled](https://prod-files-secure.s3.us-west-2.amazonaws.com/08820807-0fa7-42c4-bc95-7d349a6c2119/a7be3b4c-0ec7-43cb-89b9-28167287a97e/Untitled.png)

$M(\pi_i)$는 다음과 같이 정이되었다.

정책이 향상됨을 가정하게 되면 아래 부등식이 성립하게 된다.

![Untitled](https://prod-files-secure.s3.us-west-2.amazonaws.com/08820807-0fa7-42c4-bc95-7d349a6c2119/9ed2b7eb-fdcb-4b6a-99cc-379702db6b10/Untitled.png)
![스크린샷 2024-11-03 오전 8 22 19](https://github.com/user-attachments/assets/b2afda69-92d5-45ad-88f5-c051407c0d36)

# Optimization of Parameterized Policies

![스크린샷 2024-11-03 오전 8 22 33](https://github.com/user-attachments/assets/635bd77c-e2e3-4bca-b0c9-93717944a10d)

