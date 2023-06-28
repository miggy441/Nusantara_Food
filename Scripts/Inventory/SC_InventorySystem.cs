//You are free to use this script in Free or Commercial projects
//sharpcoderblog.com @2019

using UnityEngine;

public class SC_InventorySystem : MonoBehaviour
{
    public Texture crosshairTexture;
    public Movement playerController;
    public SC_PickItem[] availableItems; //List with Prefabs of all the available items
    public SC_PickItem[] anotherItems;
    public SC_PlaceItem[] availablePlace;

    //Available items slots
    int[] itemSlots = new int[6];
    bool showInventory = false;
    float windowAnimation = 0;
    float animationTimer = 0;

    //UI Drag & Drop
    int hoveringOverIndex = -1;
    int itemIndexToDrag = -1;
    Vector2 dragOffset = Vector2.zero;

    //Item Pick up
    SC_PickItem detectedItem;
    int detectedItemIndex;
    MeatCon Masakan;

    SC_PlaceItem detectedPlace;
    SC_PickItem outsideItem;

    bool ShowCursor = false;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        //Initialize Item Slots
        for (int i = 0; i < itemSlots.Length; i++)
        {
            itemSlots[i] = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Show/Hide inventory
        if (Input.GetKeyDown(KeyCode.G))
        {
            //showInventory = !showInventory;
            //animationTimer = 0;
            ShowCursor = !ShowCursor;

            if (ShowCursor)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                playerController.canMove = false;
                //windowAnimation = 0;
            }
            else
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                playerController.canMove = true;
                //windowAnimation = 1;
            }
        }

        //if (animationTimer < 1)
        //{
        //    animationTimer += Time.deltaTime;
        //}

        //if (showInventory)
        //{
        //    windowAnimation = Mathf.Lerp(windowAnimation, 0, animationTimer);
        //    playerController.canMove = false;
        //}
        //else
        //{
        //    windowAnimation = Mathf.Lerp(windowAnimation, 2f, animationTimer);
        //    playerController.canMove = true;
        //}

        //Begin item drag
        if (Input.GetMouseButtonDown(0) && hoveringOverIndex > -1 && itemSlots[hoveringOverIndex] > -1 && detectedPlace)
        {
            itemIndexToDrag = hoveringOverIndex;
        }

        //Release dragged item
        if (Input.GetMouseButtonUp(0) && itemIndexToDrag > -1)
        {
            if (hoveringOverIndex < 0)
            {
                //Drop the item outside
                //Instantiate(availableItems[itemSlots[itemIndexToDrag]], playerController.playerCamera.transform.position + (playerController.playerCamera.transform.forward), Quaternion.identity);
                Masakan = availableItems[itemSlots[itemIndexToDrag]].GetComponent<MeatCon>();
                Masakan.Cooking();
                itemSlots[itemIndexToDrag] = -1;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                playerController.canMove = true;
            }
            else
            {
                //Switch items between the selected slot and the one we are hovering on
                int itemIndexTmp = itemSlots[itemIndexToDrag];
                itemSlots[itemIndexToDrag] = itemSlots[hoveringOverIndex];
                itemSlots[hoveringOverIndex] = itemIndexTmp;

            }
            itemIndexToDrag = -1;
        }

        if (detectedPlace && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Taro");
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            playerController.canMove = false;            
            //string Nama = availableItems[itemSlots[hoveringOverIndex]].itemName;
            //Debug.Log(Nama);
            //Masakan = detectedItem.GetComponent<MeatCon>();
            //Masakan.Cooking();
        }

        /*if (Cursor.visible && !playerController.canMove && Input.GetKeyDown(KeyCode.Space))
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            playerController.canMove = true;
        }*/

        //Item pick up
        if (detectedItem && detectedItemIndex > -1)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                //Add the item to inventory
                int slotToAddTo = -1;
                for (int i = 0; i < itemSlots.Length; i++)
                {
                    if (itemSlots[i] == -1)
                    {
                        slotToAddTo = i;
                        break;
                    }
                }
                if (slotToAddTo > -1)
                {
                    itemSlots[slotToAddTo] = detectedItemIndex;
                    detectedItem.PickItem();
                    SFXManager.instance.UIClick();
                }
            }
        }
    }

    void FixedUpdate()
    {
        //Detect if the Player is looking at any item
        RaycastHit hit;
        Ray ray = playerController.playerCamera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));

        if (Physics.Raycast(ray, out hit, 2.5f))
        {
            Transform objectHit = hit.transform;

            if (objectHit.CompareTag("Respawn"))
            {
                if ((detectedItem == null || detectedItem.transform != objectHit) && objectHit.GetComponent<SC_PickItem>() != null)
                {
                    SC_PickItem itemTmp = objectHit.GetComponent<SC_PickItem>();

                    //Check if item is in availableItemsList
                    for (int i = 0; i < availableItems.Length; i++)
                    {
                        if (availableItems[i].itemName == itemTmp.itemName)
                        {
                            detectedItem = itemTmp;
                            detectedItemIndex = i;
                        }
                    }                    
                }
                if ((outsideItem == null || outsideItem.transform != objectHit) && objectHit.GetComponent<SC_PickItem>() != null)
                {
                    SC_PickItem itemTmp = objectHit.GetComponent<SC_PickItem>();
                    //Debug.Log("Stage 1");

                    for (int i = 0; i < anotherItems.Length; i++)
                    {
                        if (anotherItems[i].itemName == itemTmp.itemName)
                        {
                            //Debug.Log(itemTmp.itemName);
                            outsideItem = itemTmp;
                            //detectedItemIndex = i;
                        }
                    }
                }
            }
            else if (objectHit.CompareTag("PlaceItem"))
            {
                if ((detectedPlace == null || detectedPlace.transform != objectHit) && objectHit.GetComponent<SC_PlaceItem>() != null)
                {
                    SC_PlaceItem itemTmp = objectHit.GetComponent<SC_PlaceItem>();

                    for (int i = 0; i < availablePlace.Length; i++)
                    {
                        if (availablePlace[i].itemName == itemTmp.itemName)
                        {
                            detectedPlace = itemTmp;
                            //detectedItemIndex = i;
                        }
                    }
                }
            }
            else
            {
                detectedItem = null;
                detectedPlace = null;
                outsideItem = null;
            }
        }
        else
        {
            detectedItem = null;
            detectedPlace = null;
            outsideItem = null;
        }
    }

    void OnGUI()
    {
        //Inventory UI
        //GUI.Label(new Rect(5, 5, 200, 25), "Press 'Tab' to open Inventory");

        //Inventory window
        if (windowAnimation < 1)
        {
            //GUILayout.BeginArea(new Rect(10 - (430 * windowAnimation), Screen.height / 2 - 200, 602, 130), GUI.skin.GetStyle("box"));
            GUILayout.BeginArea(new Rect((-300) + (Screen.width / 2), Screen.height - 100, 600, 100), GUI.skin.GetStyle("box"));

            //GUILayout.Label("Inventory", GUILayout.Height(25));

            GUILayout.BeginVertical();
            for (int i = 0; i < itemSlots.Length; i += 6)
            {
                GUILayout.BeginHorizontal();
                //Display 3 items in a row
                for (int a = 0; a < 6; a++)
                {
                    if (i + a < itemSlots.Length)
                    {
                        if (itemIndexToDrag == i + a || (itemIndexToDrag > -1 && hoveringOverIndex == i + a))
                        {
                            GUI.enabled = false;
                        }

                        if (itemSlots[i + a] > -1)
                        {
                            if (availableItems[itemSlots[i + a]].itemPreview)
                            {
                                GUILayout.Box(availableItems[itemSlots[i + a]].itemPreview, GUILayout.Width(95), GUILayout.Height(95));
                            }
                            else
                            {
                                GUILayout.Box(availableItems[itemSlots[i + a]].itemName, GUILayout.Width(95), GUILayout.Height(95));
                            }
                        }
                        else
                        {
                            //Empty slot
                            GUILayout.Box("", GUILayout.Width(95), GUILayout.Height(95));
                        }

                        //Detect if the mouse cursor is hovering over item
                        Rect lastRect = GUILayoutUtility.GetLastRect();
                        Vector2 eventMousePositon = Event.current.mousePosition;
                        if (Event.current.type == EventType.Repaint && lastRect.Contains(eventMousePositon))
                        {
                            hoveringOverIndex = i + a;
                            if (itemIndexToDrag < 0)
                            {
                                dragOffset = new Vector2(lastRect.x - eventMousePositon.x, lastRect.y - eventMousePositon.y);
                            }
                        }

                        GUI.enabled = true;
                    }
                }
                GUILayout.EndHorizontal();
            }
            GUILayout.EndVertical();

            if (Event.current.type == EventType.Repaint && !GUILayoutUtility.GetLastRect().Contains(Event.current.mousePosition))
            {
                hoveringOverIndex = -1;
            }

            GUILayout.EndArea();
        }

        //Item dragging
        //if (itemIndexToDrag > -1)
        //{
        //    if (availableItems[itemSlots[itemIndexToDrag]].itemPreview)
        //    {
        //        GUI.Box(new Rect(Input.mousePosition.x + dragOffset.x, Screen.height - Input.mousePosition.y + dragOffset.y, 95, 95), availableItems[itemSlots[itemIndexToDrag]].itemPreview);
        //    }
        //    else
        //    {
        //        GUI.Box(new Rect(Input.mousePosition.x + dragOffset.x, Screen.height - Input.mousePosition.y + dragOffset.y, 95, 95), availableItems[itemSlots[itemIndexToDrag]].itemName);
        //    }
        //}

        //Display item name when hovering over it
        if (hoveringOverIndex > -1 && itemSlots[hoveringOverIndex] > -1 && itemIndexToDrag < 0)
        {
            GUI.Box(new Rect(Input.mousePosition.x, Screen.height - Input.mousePosition.y - 30, 100, 25), availableItems[itemSlots[hoveringOverIndex]].itemName);
        }

        if (!showInventory)
        {
            //Player crosshair
            GUI.color = detectedItem ? Color.green : Color.white;
            GUI.DrawTexture(new Rect(Screen.width / 2 - 4, Screen.height / 2 - 4, 8, 8), crosshairTexture);
            GUI.color = Color.white;

            //Pick up message
            if (detectedItem)
            {
                GUI.color = new Color(0, 0, 0, 0.84f);
                GUI.Label(new Rect(Screen.width / 2 - 75 + 1, Screen.height / 2 - 50 + 1, 150, 20), "Press 'F' to pick '" + detectedItem.itemName + "'");
                GUI.color = Color.green;
                GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height / 2 - 50, 150, 20), "Press 'F' to pick '" + detectedItem.itemName + "'");
            }
            if (detectedPlace)
            {
                GUI.color = new Color(0, 0, 0, 0.84f);
                GUI.Label(new Rect(Screen.width / 2 - 75 + 1, Screen.height / 2 - 50 + 1, 150, 20), "Press 'F' to drop '" + detectedPlace.itemName + "'");
                GUI.color = Color.green;
                GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height / 2 - 50, 150, 20), "Press 'F' to drop '" + detectedPlace.itemName + "'");
            }
            if (outsideItem)
            {
                Debug.Log(outsideItem.itemName);
                GUI.color = new Color(0, 0, 0, 0.84f);
                GUI.Label(new Rect(Screen.width / 2 - 75 + 1, Screen.height / 2 - 50 + 1, 150, 20), "'Right' to put '" + outsideItem.itemName + "'");
                GUI.color = Color.green;
                GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height / 2 - 50, 150, 20), "'Right' to put '" + outsideItem.itemName + "'");
            }
        }
    }
}