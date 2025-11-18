using UnityEngine;

// Если проект использует новый Input System, нужен пакет UnityEngine.InputSystem.
// Скрипт работает в любом случае — он проверяет и старую, и новую систему.
public class InputMouseDebug : MonoBehaviour
{
    void Update()
    {
        // Legacy input
        Vector3 legacyPos = Input.mousePosition;
        bool legacyLeft = Input.GetMouseButtonDown(0);
        bool legacyMoved = legacyPos != Vector3.zero; // простая проверка

        // New Input System (если есть)
#if ENABLE_INPUT_SYSTEM && !ENABLE_LEGACY_INPUT_MANAGER
        var mouse = UnityEngine.InputSystem.Mouse.current;
        Vector2 newPos = mouse != null ? mouse.position.ReadValue() : Vector2.negativeInfinity;
        bool newLeft = mouse != null ? mouse.leftButton.wasPressedThisFrame : false;
#else
        Vector2 newPos = Vector2.negativeInfinity;
        bool newLeft = false;
#endif

        // Вывод в консоль — друг должен смотреть Unity Console во время Play
        Debug.Log($"[InputDebug] LegacyPos={legacyPos} LegacyClick={legacyLeft} | NewPos={newPos} NewClick={newLeft}");
    }
}
