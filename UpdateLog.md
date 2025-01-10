# 250106
## 개인 프로젝트 시작
[【한글자막】 RPG 코어 컴뱃 크리에이터: 중급 Unity C# 코딩 마스터하기!](https://www.udemy.com/course/rpg-core-combat-creater-intermediate-unity-c-korean)

##  기본 설정  
기본 IDE를 VSC로 설정
## 터레인 생성법 학습  
## 작은 맵 생성

### 9. 간단한 샌드박스 생성까지 완료
---  
  
# 250107

## VSC 오류 해결 (여기서 시간 다씀;)
[참고자료](https://portable-paper.tistory.com/entry/%ED%94%84%EB%A1%9C%EC%A0%9D%ED%8A%B8-assembly-csharpcsproj%EC%9D%84%EB%A5%BC-%EB%A1%9C%EB%93%9C%ED%95%98%EC%A7%80-%EB%AA%BB%ED%96%88%EC%8A%B5%EB%8B%88%EB%8B%A4-one-or-more-errors-occurred-%EC%9D%B4-%ED%94%84%EB%A1%9C%EC%A0%9D%ED%8A%B8%EB%8A%94-c-dev-kit%EC%97%90%EC%84%9C-%EC%A7%80%EC%9B%90%EB%90%98%EC%A7%80-%EC%95%8A%EC%8A%B5%EB%8B%88%EB%8B%A4?category=1089228)

SDK 설치했는데도 오류 나서 위의 방법 참고함
+omnisharp Use Modern Net 해제해야 함

## 네비게이션 시스템 사용
[참고자료](https://wergia.tistory.com/224)

- NavMesh : 캐릭터가 이동할 수 있는 표면을 다각형으로 구성하는 것
- Nav Mesh Agent : NavMesh 안에서 이동할 수 있도록 조정하는 클래스

- NavMesh를 Bake할 때 Navigation Static 체크되어있는 오브젝트에 대해서는 더 자세히 구울 수 있음  
  
- Bake Advanced 설정에서 에이전트 반경 당 복셀 수가 많으면 더 상세하게 만들 수 있음  
복셀 사이즈를 임의로 조정할 수 있으며 복셀 사이즈가 커지면 반경 당 복셀 수가 줄어듬  
=> 이동 가능한 길을 너무 자세하지 않게 거시적으로 만들 수 있음  

- Min Region Area가 너무 작으면 건물 옥상도 하나의 Region으로 판단해서 이동하려고 시도함  
따라서 적당히 조절하는게 필요함  
연속적인 월드가 구성되어있다면 Min Region Area를 높은 값으로 설정해도 괜찮음  

- Nav Mesh Obstacle : 장애물 처리. Carve에 체크하면 동적으로 NavMesh를 파먹어서 그쪽으로 이동할 수 없게 함  

### 11. 내비메시 조정까지 완료  
  
# 250109

## 레이캐스팅을 사용해 캐릭터 움직이기
- 레이캐스팅 : 카메라의 원점에서부터 마우스로 클릭한 지점까지 이어지는 특정한 벡터를 구하는 것  
    - 보이지 않는 선(Ray)은 카메라 원점 > 클리핑 평면 (사용자의 화면 비율에 맞는 평면) > 인게임 맵 까지 이어짐   

- Debug.DrawRay : 시작점과 방향을 정하면 그에 맞는 선을 그음  
- Camera.ScreenPointToRay : 카메라의 원점에서부터 특정 지점까지 이어지는 선을 그음  

- Ray 구조체 : origin(원점)과 direction(방향)을 가지고 있는 벡터 구조체  
- RaycastHit 구조체 : Ray의 충돌지점에 대한 구조체.  
    - RaycastHit.point는 클릭해서 닿은 위치값이기 때문에 주로 사용됨  

- MoveToCursor() : 레이캐스팅을 통해 캐릭터를 움직임
    1. 카메라에서 화면으로 레이캐스팅을 진행함
    2. 레이가 터레인과 충돌한 지점을 구함
    3. 그 지점을 캐릭터의 NavMeshAgent의 destination으로 지정함.

## 고정 카메라 만들기

- 아무런 설정도 하지 않고, 플레이어의 자식으로 메인 카메라를 두면 회전을 같이 함.  
- 이런 일을 방지하기 위해서, 플레이어의 자식으로 Follow Camera Game Object를 생성함
- 카메라는 Follow Camera의 자식으로 들어감.

### 14. 고정 팔로우 카메라 생성까지 완료

# 250110
## 플레이어 캐릭터에 제대로 된 텍스쳐 입히기
- 기존 Player 프리팹의 자식으로 텍스쳐 프리팹을 둠
- 그리고 Player 프리팹에 있던 캡슐 메쉬와 캡슐 콜리더 삭제
- NavMeshAgent 기준점도 0으로 변경
- 캐릭터 메쉬 크기에 맞게 NavMeshAgent 두께 조절하기
- 네스티드 프리팹 : 프리팹 안에 프리팹이 저장되어 있는 것

## 플레이어 캐릭터 움직이기
- Animator 컴포넌트 : 게임 오브젝트에 애니메이션을 할당함
- Animator Controller : 애니메이션과 트랜지션(상태 변화)의 배열
- Animation : 구체적인 움직임 
- Blend Tree : 여러 개의 애니메이션을 갖고 자연스럽게 연결함

- Animator Controller 설정
    1. Entry : 게임이 시작되었을 때의 상태. 애니메이터가 생성된 상황
    2. 빈 공간 우클릭 > New Blend Tree : 새 블렌드 트리를 생성함
    3. 블렌드 트리 더블클릭 : 블렌드 트리 수정 가능
    4. Add Motion Field : 블렌드 트리에서 섞을 모션을 추가함
    5. Blend 변수 조작 : Blend 변수에 따라 모션을 다르게 섞을 수 있음!

- Animator 컴포넌트 설정 :
    1. 생성한 Animator Contorller를 드래그 앤 드롭
    2. Avatar의 경우 제대로 설정하지 않으면 애니메이션과 메쉬/리깅 정보가 안맞아서 오류날 수 있음
    3. Apply Root Motion을 적용하면 애니메이션 시스템 자체가 캐릭터가 가는 방향으로 움직임
    -  저걸 적용하면 캐릭터의 움직임이 우선순위가 아니라, 애니메이션을 우선적으로 판단하기 때문에 애니메이션이 한 번 움직이는 만큼 무조건 움직여야 함.

- 컨텍스트 정리 :
    - 속도 : 시간에 따른 속도 변화 (!= 속력)
    - NavMeshAgent는 속도를 가고자 하는 방향과 해당 위치까지의 속력을 묶음으로 봄
    - 우리의 캐릭터 이동 애니메이션은 Z축 이동 속도에 관심이 있음

- 목표 :  
    1. NavMeshAgent에서 전역 속도를 가져옴 (좌회전/우회전 개념 X)
    2. 이 속도를 캐릭터에 연결된 로컬 변수로 변환함
    3. 애니메이터의 Blend 변수를 캐릭터의 전진 속력으로 설정함

- 애니메이션 구조를 보면 기준 트랜스폼이 나와있음. Blend의 모션 임계값을 자동 설정하지 않으면 기준 트랜스폼을 따라감  

### 16.움직임에 애니메이션 적용 일부 완료