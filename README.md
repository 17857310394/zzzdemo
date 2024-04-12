# ZZZDemo源码

#### 介绍
仅供开发者学习使用，请勿随意外传，禁止商业用途，包含相关官方美术素材，侵权联系作者删除。

#### Demo架构
第三人称控制采用CharacterController下的Move方法实现移动，使用OnAnimaionMove动画更新频率刷新的根运动实现的移动。
动画的过渡和播放逻辑基于Unity内置Animator组件+有限状态机。所有动画状态继承Istate接口，每一种状态机只允许刷新一种状态，为角色分了MovementStateMachine和ComboStateMachine。每一类状态机继承StateMachine这个基类，基类实现Istate的切换方法，子类实现各种继承IState接口状态的缓存和初始化。各种状态内部实现输入事件或者自定义的注册与注销、动画播放逻辑、数据的初始或者变更、状态的退出及过渡等逻辑。
人物的连招基于ComboState控制攻击键的输入的事件、预输入动画事件、必要时间动画事件、打断连招衔接动画事件。
CharacterHealth注册伤害事件、处理对应攻击者的伤害、受伤动画、格挡动画以及生成受击音效、受击特效
第三人称镜头和技能镜头基于Cinemachine的 State-Driven Camera、Dolly轨道相机、Timeline动态更新Dolly数据。移动状态的水平居中通过Cinamachine计算实现

ScriptableObject实现人物所有不变数据的储存、ReusableData实现人物变更数据的储存和变更。
BindableProperty实现变更数据的事件绑定。
TimerManager工具类计时器工具提供基于ScaleTime倒计时触发的委托函数、基于UnScaleTime倒计时触发的委托函数、以及可以销毁正在计时委托的API。
GameEventManager工具类事件工具提供事件注册（用string类型映射一个传入T或多个T参数委托事件）、事件触发、事件销毁的API。
SFX_PoolManger工具类提供一个用SoundStyle枚举类型映射音效预制体激活的API、一个用SoundStyle枚举类型和String映射音效预制体激活的API，所有音效预制体的生成的配置完全自动化，基于可在编辑器状态下执行的CreateSoundPoolItem和CreateComboPoolTool的editor文件。
所有PoolManger基于对象池设计模式。
CameraHitFeel工具类控制角色慢动作、顿帧。提供改变ScaleTime的API、只改变特定角色动画播放速度和场景中所有特效播放速度的API...

#### 使用说明
下载Zip，解压，直接用UnityHub打开根文件夹，打开项目后进入NO1场景

#### 参考资料

1. 有限状态机：https://www.youtube.com/watch?v=Jrlvgf4_HQE
2. 连招、单例、工具类：https://space.bilibili.com/362510628?spm_id_from=333.337.0.0
3. 框架思路：https://space.bilibili.com/60450548/article