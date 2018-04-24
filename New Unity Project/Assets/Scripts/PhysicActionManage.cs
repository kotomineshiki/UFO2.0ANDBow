using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicActionManager : MonoBehaviour, ActionManager
{

    /** 
 * 这个文件用来管理飞碟的飞行动作 
 */

    public SceneController sceneController;
    public int DiskNumber = 0;


    private Dictionary<int, SSAction> actions = new Dictionary<int, SSAction>();       
    private List<SSAction> waitingAdd = new List<SSAction>();                           
    private List<int> waitingDelete = new List<int>();                                  //动作的删除队列，在这个对象保存的动作会稍后删除  

    protected void Start()
    {
        sceneController = (SceneController)SceneController.getInstance();

    }

    // Update is called once per frame  
    protected void FixedUpdate()
    {

        foreach (SSAction ac in waitingAdd) actions[ac.GetInstanceID()] = ac;
        waitingAdd.Clear();

        foreach (KeyValuePair<int, SSAction> kv in actions)
        {
            SSAction ac = kv.Value;
            if (ac.destroy)
            {
                waitingDelete.Add(ac.GetInstanceID());
            }
            else if (ac.enable)
            {
            }
        }

        //把删除队列里所有的动作删除  
        foreach (int key in waitingDelete)
        {
            SSAction ac = actions[key];
            actions.Remove(key);
            DestroyObject(ac);
        }
        waitingDelete.Clear();
    }

    //初始化一个动作  
    public void RunAction(GameObject gameobject, SSAction action)
    {

        waitingAdd.Add(action);
        action.Start();
    }


    public void SSActionEvent(SSAction source,
  
        int intParam = 0,
        string strParam = null,
        UnityEngine.Object objectParam = null)
    {

    }

    public void StartThrow(Queue<GameObject> diskQueue)
    {
       // CCFlyActionFactory cf = Singleton<CCFlyActionFactory>.Instance;
        foreach (GameObject tmp in diskQueue)
        {
          //  RunAction(tmp, cf.GetSSAction(), (ISSActionCallback)this);
        }
    }

    public int getDiskNumber()
    {
        return DiskNumber;
    }

    public void setDiskNumber(int num)
    {
        DiskNumber = num;
    }
}