using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lxs_LayerManager : MonoBehaviour {

    static public int lxsLayer1 = 15;//Player常量，设置玩家
    static public int fkLayer2 = 16;
    static public int gyqLayer3 = 17;
    static public int whlLayer4 = 18;
    static public int hhyLayer5 = 19;
    static public int hyfLayer6 = 17;
    static public int ywjLayer7 = 17;
    static public int zmzLayer8 = 17;

    static public LayerMask GetEnemyLayer(lxs_Team team)
    {
        LayerMask mask = 0;
        switch (team)
        {

            case lxs_Team.lxs:
                mask = (1 << fkLayer2) | (1 << gyqLayer3) | (1 << whlLayer4)
                        | (1 << hhyLayer5) | (1 << hyfLayer6) | (1 << ywjLayer7) | (1 << zmzLayer8);//位移操作
                break;

            case lxs_Team.fk:
                mask = (1 << lxsLayer1) | (1 << gyqLayer3) | (1 << whlLayer4)
                        | (1 << hhyLayer5) | (1 << hyfLayer6) | (1 << ywjLayer7) | (1 << zmzLayer8);
                break;

            case lxs_Team.gyq:
                mask = (1 << fkLayer2) | (1 << lxsLayer1) | (1 << whlLayer4)
                        | (1 << hhyLayer5) | (1 << hyfLayer6) | (1 << ywjLayer7) | (1 << zmzLayer8);
                break;

            case lxs_Team.whl:
                mask = (1 << fkLayer2) | (1 << gyqLayer3) | (1 << lxsLayer1)
                    | (1 << hhyLayer5) | (1 << hyfLayer6) | (1 << ywjLayer7) | (1 << zmzLayer8);
                break;

            case lxs_Team.hhy:
                mask = (1 << fkLayer2) | (1 << gyqLayer3) | (1 << whlLayer4)
                    | (1 << lxsLayer1) | (1 << hyfLayer6) | (1 << ywjLayer7) | (1 << zmzLayer8);
                break;

            case lxs_Team.hyf:
                mask = (1 << fkLayer2) | (1 << gyqLayer3) | (1 << whlLayer4)
                    | (1 << hhyLayer5) | (1 << lxsLayer1) | (1 << ywjLayer7) | (1 << zmzLayer8);
                break;

            case lxs_Team.ywj:
                mask = (1 << fkLayer2) | (1 << gyqLayer3) | (1 << whlLayer4)
                    | (1 << hhyLayer5) | (1 << hyfLayer6) | (1 << lxsLayer1) | (1 << zmzLayer8);
                break;

            case lxs_Team.zmz:
                mask = (1 << fkLayer2) | (1 << gyqLayer3) | (1 << whlLayer4)
                    | (1 << hhyLayer5) | (1 << hyfLayer6) | (1 << ywjLayer7) | (1 << lxsLayer1);
                break;


        }
        return mask;
    }
}
